using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Include PCAN-USB namespace
/// </summary>
using Peak.Can.Basic;
using TPCANHandle = System.UInt16;
using TPCANBitrateFD = System.String;
using TPCANTimestampFD = System.UInt64;


namespace CANopen_ctrl_app
{
	public partial class Form1 : Form
	{
		#region Structures
		/// <summary>
		/// Message Status structure used to show CAN Messages
		/// in a ListView
		/// </summary>
		private class MessageStatus
		{
			private TPCANMsgFD m_Msg;
			private TPCANTimestampFD m_TimeStamp;
			private TPCANTimestampFD m_oldTimeStamp;
			private int m_iIndex;
			private int m_Count;
			private bool m_bShowPeriod;
			private bool m_bWasChanged;

			public MessageStatus(TPCANMsgFD canMsg, TPCANTimestampFD canTimestamp, int listIndex)
			{
				m_Msg = canMsg;
				m_TimeStamp = canTimestamp;
				m_oldTimeStamp = canTimestamp;
				m_iIndex = listIndex;
				m_Count = 1;
				m_bShowPeriod = true;
				m_bWasChanged = false;
			}

			public void Update(TPCANMsgFD canMsg, TPCANTimestampFD canTimestamp)
			{
				m_Msg = canMsg;
				m_oldTimeStamp = m_TimeStamp;
				m_TimeStamp = canTimestamp;
				m_bWasChanged = true;
				m_Count += 1;
			}

			public TPCANMsgFD CANMsg
			{
				get { return m_Msg; }
			}

			public TPCANTimestampFD Timestamp
			{
				get { return m_TimeStamp; }
			}

			public int Position
			{
				get { return m_iIndex; }
			}

			public string TypeString
			{
				get { return GetMsgTypeString(); }
			}

			public string IdString
			{
				get { return GetIdString(); }
			}

			public string DataString
			{
				get { return GetDataString(); }
			}

			public int Count
			{
				get { return m_Count; }
			}

			public bool ShowingPeriod
			{
				get { return m_bShowPeriod; }
				set
				{
					if (m_bShowPeriod ^ value)
					{
						m_bShowPeriod = value;
						m_bWasChanged = true;
					}
				}
			}

			public bool MarkedAsUpdated
			{
				get { return m_bWasChanged; }
				set { m_bWasChanged = value; }
			}

			public string TimeString
			{
				get { return GetTimeString(); }
			}

			private string GetTimeString()
			{
				double fTime;

				fTime = (m_TimeStamp / 1000.0);
				if (m_bShowPeriod)
					fTime -= (m_oldTimeStamp / 1000.0);
				return fTime.ToString("F1");
			}

			private string GetDataString()
			{
				string strTemp;

				strTemp = "";

				if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
					return "Remote Request";
				else
					for (int i = 0; i < Form1.GetLengthFromDLC(m_Msg.DLC, (m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_FD) == 0); i++)
						strTemp += string.Format("{0:X2} ", m_Msg.DATA[i]);

				return strTemp;
			}

			private string GetIdString()
			{
				// We format the ID of the message and show it
				//
				if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) == TPCANMessageType.PCAN_MESSAGE_EXTENDED)
					return string.Format("{0:X8}h", m_Msg.ID);
				else
					return string.Format("{0:X3}h", m_Msg.ID);
			}

			private string GetMsgTypeString()
			{
				string strTemp;

				if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_STATUS) == TPCANMessageType.PCAN_MESSAGE_STATUS)
					return "STATUS";

				if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_ERRFRAME) == TPCANMessageType.PCAN_MESSAGE_ERRFRAME)
					return "ERROR";

				if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) == TPCANMessageType.PCAN_MESSAGE_EXTENDED)
					strTemp = "EXT";
				else
					strTemp = "STD";

				if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
					strTemp += "/RTR";
				else
					if ((int)m_Msg.MSGTYPE > (int)TPCANMessageType.PCAN_MESSAGE_EXTENDED)
				{
					strTemp += " [ ";
					if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_FD) == TPCANMessageType.PCAN_MESSAGE_FD)
						strTemp += " FD";
					if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_BRS) == TPCANMessageType.PCAN_MESSAGE_BRS)
						strTemp += " BRS";
					if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_ESI) == TPCANMessageType.PCAN_MESSAGE_ESI)
						strTemp += " ESI";
					strTemp += " ]";
				}

				return strTemp;
			}

		}
		#endregion

		#region Delegates
		/// <summary>
		/// Read-Delegate Handler
		/// </summary>
		private delegate void ReadDelegateHandler();
		#endregion

		#region Members
		/// <summary>
		/// Saves the desired connection mode
		/// </summary>
		private bool m_IsFD;
		/// <summary>
		/// Saves the handle of a PCAN hardware
		/// </summary>
		private TPCANHandle m_PcanHandle;
		/// <summary>
		/// Saves the baudrate register for a conenction
		/// </summary>
		private TPCANBaudrate m_Baudrate;
		/// <summary>
		/// Saves the type of a non-plug-and-play hardware
		/// </summary>
		private TPCANType m_HwType;
		/// <summary>
		/// Stores the status of received messages for its display
		/// </summary>
		private System.Collections.ArrayList m_LastMsgsList;
		/// <summary>
		/// Read Delegate for calling the function "ReadMessages"
		/// </summary>
		private ReadDelegateHandler m_ReadDelegate;
		/// <summary>
		/// Receive-Event
		/// </summary>
		private System.Threading.AutoResetEvent m_ReceiveEvent;
		/// <summary>
		/// Thread for message reading (using events)
		/// </summary>
		private System.Threading.Thread m_ReadThread;
		/// <summary>
		/// Handles of the current available PCAN-Hardware
		/// </summary>
		private TPCANHandle[] m_HandlesArray;
		#endregion

		#region defines
		const uint A_ROUND_ENC_CNT = 0x40000;

		const uint SDO_COB_ID = 0x600;
		const uint SDO_RESP_COB_ID = 0x580;

		const uint IDX_STORE_PARAMS = 0x101001;
		const uint IDX_RESTORE_PARAMS = 0x101101;
		const uint IDX_NODE_ID = 0x200000;
		const uint IDX_CONTROL_WORD = 0x604000;
		const uint IDX_STATUS_WORD = 0x604100;
		const uint IDX_OPERATION_MODE = 0x606000;
		const uint IDX_ACTUAL_POSITION = 0x606400;
		const uint IDX_TARGET_TORQUE = 0x607100;
		const uint IDX_TARGET_POSITION = 0x607A00;
		const uint IDX_PROFILE_VELOCITY = 0x608100;
		const uint IDX_PROFILE_ACCELERATION = 0x608300;
		const uint IDX_PROFILE_DECELERATION = 0x608400;
		const uint IDX_TARGET_VELOCITY = 0x60FF00;
		#endregion


		/// <summary>
		/// Form1
		/// </summary>
		public Form1()
		{
			InitializeComponent();

			cbb_bitrate_sel.SelectedIndex = 0;
			cbb_hardware_sel.SelectedIndex = 0;

			m_PcanHandle = Convert.ToUInt16("51", 16);

			nud_actual_posi.Controls[0].Visible = false;
		}


		/// <summary>
		/// Form1_FormClosing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (check_connection_state() == false)
			{
				return;
			}

			// Releases a current connected PCAN-Basic channel
			//
			PCANBasic.Uninitialize(m_PcanHandle);
		}


		#region PCAN setting
		/// <summary>
		/// Configures the PCAN-Trace file for a PCAN-Basic Channel
		/// </summary>
		private void ConfigureTraceFile()
		{
			UInt32 iBuffer;
			TPCANStatus stsResult;

			// Configure the maximum size of a trace file to 5 megabytes
			//
			iBuffer = 5;
			stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_SIZE, ref iBuffer, sizeof(UInt32));
			//if (stsResult != TPCANStatus.PCAN_ERROR_OK)
			//    IncludeTextMessage(GetFormatedError(stsResult));

			// Configure the way how trace files are created: 
			// * Standard name is used
			// * Existing file is ovewritten, 
			// * Only one file is created.
			// * Recording stopts when the file size reaches 5 megabytes.
			//
			iBuffer = PCANBasic.TRACE_FILE_SINGLE | PCANBasic.TRACE_FILE_OVERWRITE;
			stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_CONFIGURE, ref iBuffer, sizeof(UInt32));
			//if (stsResult != TPCANStatus.PCAN_ERROR_OK)
			//    IncludeTextMessage(GetFormatedError(stsResult));
		}

		/// <summary>
		/// Help Function used to get an error as text
		/// </summary>
		/// <param name="error">Error code to be translated</param>
		/// <returns>A text with the translated error</returns>
		private string GetFormatedError(TPCANStatus error)
		{
			StringBuilder strTemp;

			// Creates a buffer big enough for a error-text
			//
			strTemp = new StringBuilder(256);
			// Gets the text using the GetErrorText API function
			// If the function success, the translated error is returned. If it fails,
			// a text describing the current error is returned.
			//
			if (PCANBasic.GetErrorText(error, 0, strTemp) != TPCANStatus.PCAN_ERROR_OK)
				return string.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", error);
			else
				return strTemp.ToString();
		}


		/// <summary>
		/// Convert a CAN DLC value into the actual data length of the CAN/CAN-FD frame.
		/// </summary>
		/// <param name="dlc">A value between 0 and 15 (CAN and FD DLC range)</param>
		/// <param name="isSTD">A value indicating if the msg is a standard CAN (FD Flag not checked)</param>
		/// <returns>The length represented by the DLC</returns>
		public static int GetLengthFromDLC(int dlc, bool isSTD)
		{
			if (dlc <= 8)
				return dlc;

			if (isSTD)
				return 8;

			switch (dlc)
			{
				case 9:
					return 12;
				case 10:
					return 16;
				case 11:
					return 20;
				case 12:
					return 24;
				case 13:
					return 32;
				case 14:
					return 48;
				case 15:
					return 64;
				default:
					return dlc;
			}
		}
		#endregion


		#region CANopen frames
		/// <summary>
		/// CANフレームの送信
		/// </summary>
		/// <param name="can_id"></param>
		/// <param name="w_data"></param>
		/// <returns></returns>
		private bool WriteBytes(uint can_id, byte[] w_data)
		{
			bool ret = false;
			TPCANMsg CANMsg;

			PCANBasic.Reset(m_PcanHandle);

			// We create a TPCANMsg message structure 
			//
			CANMsg = new TPCANMsg();
			CANMsg.DATA = new byte[8];

			// We configurate the Message.  The ID,
			// Length of the Data, Message Type
			//
			CANMsg.ID = can_id;
			CANMsg.LEN = (w_data.Length > 8) ? (byte)8 : (byte)w_data.Length;
			CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;

			// We get so much data as the Len of the message
			//
			for (int i = 0; i < (int)CANMsg.LEN; i++)
			{
				CANMsg.DATA[i] = w_data[i];
			}

			// The message is sent to the configured hardware
			//
			TPCANStatus stsResult;
			for (int i = 0; i < 10; i++)
			{
				stsResult = PCANBasic.Write(m_PcanHandle, ref CANMsg);
				if (stsResult == TPCANStatus.PCAN_ERROR_OK)
				{
					ret = true;
					break;
				}
				else
				{
					Thread.Sleep(50);
				}
			}

			return ret;
		}


		/// <summary>
		/// CANフレームの受信
		/// </summary>
		/// <param name="r_data"></param>
		/// <returns></returns>
		private bool ReceiveBytes(out uint r_data)
		{
			bool ret = false;

			r_data = 0;

			// We execute the "Read" function of the PCANBasic                
			//
			TPCANMsg CANMsg;
			TPCANTimestamp CANTimeStamp;
			for (int i = 0; i < 10; i++)
			{
				TPCANStatus stsResult = PCANBasic.Read(m_PcanHandle, out CANMsg, out CANTimeStamp);
				if (stsResult == TPCANStatus.PCAN_ERROR_OK)
				{
					if (CANMsg.DATA[0] == 0x80)
					{
						// error
					}
					else if (CANMsg.DATA[0] > 0x0)
					{
						ret = true;
						r_data = (uint)CANMsg.DATA[4];              // 最下位バイト
						r_data += (uint)CANMsg.DATA[5] * 0x100;     // ↓
						r_data += (uint)CANMsg.DATA[6] * 0x10000;   // ↓
						r_data += (uint)CANMsg.DATA[7] * 0x1000000; // 最上位バイト
					}
					break;
				}
				else
				{
					Thread.Sleep(50);
				}
			}

			return ret;
		}


		/// <summary>
		/// SDOの送信リクエスト : Roboservoからオブジェクトの値を読み出す
		/// </summary>
		/// <param name="nodeID"></param>
		/// <param name="Index"></param>
		/// <param name="r_data"></param>
		/// <returns></returns>
		private bool send_TSDO(uint nodeID, uint Index, out uint r_data)
		{
			bool ret = false;

			r_data = 0;

			if (check_connection_state() == true)
			{
				byte[] w_data = new byte[8];
				w_data[0] = 0x40;                   // 送信要求コマンド
				w_data[1] = (byte)(Index >> 8);     // インデックス(下位バイト)
				w_data[2] = (byte)(Index >> 16);    // インデックス(上位バイト)
				w_data[3] = (byte)(Index >> 0);     // サブインデックス
				w_data[4] = 0;
				w_data[5] = 0;
				w_data[6] = 0;
				w_data[7] = 0;

				// send
				ret = WriteBytes((SDO_COB_ID + nodeID), w_data);
				if (ret == true)
				{
					// rec
					ret = ReceiveBytes(out r_data);
				}
			}

			return ret;
		}


		/// <summary>
		/// SDOの受信リクエスト : Roboservoへオブジェクトの値を書込む
		/// </summary>
		/// <param name="nodeID"></param>
		/// <param name="Index"></param>
		/// <param name="s_data"></param>
		/// <returns></returns>
		private bool send_RSDO(uint nodeID, uint Index, uint s_data)
		{
			bool ret = false;

			if (check_connection_state() == true)
			{
				byte[] w_data = new byte[8];
				w_data[0] = 0x22;                   // 受信要求コマンド
				w_data[1] = (byte)(Index >> 8);     // インデックス(下位バイト)
				w_data[2] = (byte)(Index >> 16);    // インデックス(上位バイト)
				w_data[3] = (byte)(Index >> 0);     // サブインデックス
				w_data[4] = (byte)(s_data >> 0);    // 送信データ(最下位バイト)
				w_data[5] = (byte)(s_data >> 8);    // 送信データ
				w_data[6] = (byte)(s_data >> 16);   // 送信データ
				w_data[7] = (byte)(s_data >> 24);   // 送信データ(最上位バイト)

				ret = WriteBytes((SDO_COB_ID + nodeID), w_data);
				if (ret == true)
				{
					// rec
					uint r_data = 0;
					ret = ReceiveBytes(out r_data);
				}
			}

			return ret;
		}
		#endregion



		/************************************************************************************/
		/*	Tab : Interface																	*/
		/************************************************************************************/

		/// <summary>
		/// PCAN-USBとの通信を開始する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_connect_Click(object sender, EventArgs e)
		{
			TPCANStatus stsResult = TPCANStatus.PCAN_ERROR_OK;

			UInt32 iBuffer = 0;
			try
			{
				stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_CHANNEL_CONDITION, out iBuffer, sizeof(UInt32));
			}
			catch
			{
				;
			}
			if (iBuffer == PCANBasic.PCAN_CHANNEL_AVAILABLE)
			{
				// Connects a selected PCAN-Basic channel
				//
				stsResult = PCANBasic.Initialize(
					m_PcanHandle,
					m_Baudrate,
					m_HwType,
					Convert.ToUInt32("1", 16),
					Convert.ToUInt16("3"));

				if (stsResult != TPCANStatus.PCAN_ERROR_OK)
				{
					if (stsResult != TPCANStatus.PCAN_ERROR_CAUTION)
					{
						MessageBox.Show(GetFormatedError(stsResult));
					}
					else
					{
						stsResult = TPCANStatus.PCAN_ERROR_OK;
					}
				}
				else
				{
					// Prepares the PCAN-Basic's PCAN-Trace file
					//
					ConfigureTraceFile();
				}

				// Sets the connection status of the main-form
				//
				if (stsResult == TPCANStatus.PCAN_ERROR_OK)
				{
					btn_connect.Text = "Connected";
					btn_connect.BackColor = Color.Lime;
				}
			}
			else if (iBuffer >= PCANBasic.PCAN_CHANNEL_OCCUPIED)
			{
				if (check_connection_state() == true)
				{
					// Releases a current connected PCAN-Basic channel
					//
					PCANBasic.Uninitialize(m_PcanHandle);

					// Sets the connection status of the main-form
					//
					if (stsResult == TPCANStatus.PCAN_ERROR_OK)
					{
						btn_connect.Text = "Disconnected";
						btn_connect.BackColor = Color.Red;
					}
				}
				else
				{
					// Connects a selected PCAN-Basic channel
					//
					stsResult = PCANBasic.Initialize(m_PcanHandle, m_Baudrate, m_HwType, Convert.ToUInt32("1", 16), Convert.ToUInt16("3"));

					// Sets the connection status of the main-form
					//
					if (stsResult == TPCANStatus.PCAN_ERROR_OK)
					{
						btn_connect.Text = "Connected";
						btn_connect.BackColor = Color.Lime;
					}
				}
			}
		}


		/// <summary>
		/// PCAN-USBの接続を確認する
		/// </summary>
		/// <returns></returns>
		private bool check_connection_state()
		{
			return (btn_connect.BackColor == Color.Lime) ? true : false;
		}


		/// <summary>
		/// bitrateの選択
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbb_bitrate_sel_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Saves the current selected baudrate register code
			//
			switch (cbb_bitrate_sel.SelectedIndex)
			{
				case 0:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_1M;
					break;
				case 1:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_800K;
					break;
				case 2:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_500K;
					break;
				case 3:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_250K;
					break;
				case 4:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_125K;
					break;
				case 5:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_100K;
					break;
				case 6:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_95K;
					break;
				case 7:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_83K;
					break;
				case 8:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_50K;
					break;
				case 9:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_47K;
					break;
				case 10:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_33K;
					break;
				case 11:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_20K;
					break;
				case 12:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_10K;
					break;
				case 13:
					m_Baudrate = TPCANBaudrate.PCAN_BAUD_5K;
					break;
			}
		}



		/************************************************************************************/
		/*	Tab : Node-ID setting															*/
		/************************************************************************************/

		/// <summary>
		/// 接続されているNode-IDを検索する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_node_scan_Click(object sender, EventArgs e)
		{
			PCANBasic.Reset(m_PcanHandle);

			tb_connecting_node.Text = "";
			this.Refresh();

			// Node-ID 1～9 までを検索する
			uint rec_data = 0;
			for (uint i = 1; i <= 9; i++)
			{
				if (send_TSDO(i, IDX_STATUS_WORD, out rec_data) == true)
				{
					// Roboservoからの返信で接続を認識
					tb_connecting_node.Text += i.ToString() + ", ";
				}
			}
		}


		/// <summary>
		/// Node-IDを設定する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_param_send_Click(object sender, EventArgs e)
		{
			PCANBasic.Reset(m_PcanHandle);

			((Button)sender).BackColor = Color.Transparent;
			this.Refresh();

			// Node-ID(Index:0x2000-0x00)に対して新しいIDを送信する
			if (send_RSDO((uint)nud_nodeID_before.Value, IDX_NODE_ID, (uint)nud_nodeID_after.Value) == false)
			{
				((Button)sender).BackColor = Color.Red;
				return;
			}

			((Button)sender).BackColor = Color.Lime;
		}


		/// <summary>
		/// 変更を保存する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_param_save_Click(object sender, EventArgs e)
		{
			PCANBasic.Reset(m_PcanHandle);

			((Button)sender).BackColor = Color.Transparent;
			this.Refresh();

			// Store Parameter Field(Index:0x101001)に対してASCIIコード"save"を送信する
			if (send_RSDO((uint)nud_nodeID_before.Value, IDX_STORE_PARAMS, 0x65766173) == false)
			{
				((Button)sender).BackColor = Color.Red;
				return;
			}

			((Button)sender).BackColor = Color.Lime;
		}


		/// <summary>
		/// Roboservoを再起動させる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_reboot_Click(object sender, EventArgs e)
		{
			PCANBasic.Reset(m_PcanHandle);

			((Button)sender).BackColor = Color.Transparent;
			this.Refresh();

			// Controlword(Index:0x6040-0x00)へShutdownコマンド(0x0006)を送信する
			if (send_RSDO((uint)nud_nodeID_before.Value, IDX_CONTROL_WORD, 0x0006) == false)
			{
				((Button)sender).BackColor = Color.Red;
				return;
			}
			Thread.Sleep(100);

			// Controlword(Index:0x6040-0x00)へRebootコマンド(0x0806)を送信する
			send_RSDO((uint)nud_nodeID_before.Value, IDX_CONTROL_WORD, 0x0806);
			Thread.Sleep(3000);

			((Button)sender).BackColor = Color.Lime;
		}


		/// <summary>
		/// Roboservoのパラメータを初期化する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_param_restore_Click(object sender, EventArgs e)
		{
			PCANBasic.Reset(m_PcanHandle);

			((Button)sender).BackColor = Color.Transparent;
			this.Refresh();

			// Restore Default Parameters(Index:0x101101)に対してASCIIコード"load"を送信する
			if (send_RSDO((uint)nud_nodeID_before.Value, IDX_RESTORE_PARAMS, 0x64616F6C) == false)
			{
				((Button)sender).BackColor = Color.Red;
				return;
			}

			((Button)sender).BackColor = Color.Lime;
		}



		/************************************************************************************/
		/*	Tab : Torque control															*/
		/************************************************************************************/

		/// <summary>
		/// Roboservoをトルク制御モードで起動する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_trp_switch_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			nud_target_torque.Value = (decimal)0.0;    // トルク指令値を0.0%に設定

			if (button.Text == "トルク　OFF")
			{
				// 制御モードを変更する為に、Controlword(Index:0x6040-0x00)へShutdownコマンド(0x0006)を送信する
				if (send_RSDO((uint)nud_trq_nodeID.Value, IDX_CONTROL_WORD, 0x0006) == true)
				{
					// 制御モード変更
					// Modes of Operation(Index:0x6060-0x00)へCyclic synchronous torque mode(0x0A)を送信する
					if (send_RSDO((uint)nud_trq_nodeID.Value, IDX_OPERATION_MODE, 0x0A) == true)
					{
						// Controlword(Index:0x6040-0x00)へShutdownコマンド(0x0006)を送信する
						if (send_RSDO((uint)nud_trq_nodeID.Value, IDX_CONTROL_WORD, 0x0006) == true)
						{
							// Controlword(Index:0x6040-0x00)へSwitch ON +Enable operationコマンド(0x000F)を送信する
							if (send_RSDO((uint)nud_trq_nodeID.Value, IDX_CONTROL_WORD, 0x000F) == true)
							{
								// Roboservoの起動完了
								button.Text = "トルク　ON";
								button.BackColor = Color.Yellow;
							}
						}

					}
				}
			}
			else
			{
				button.Text = "トルク　OFF";
				button.BackColor = Color.Transparent;

				// Roboservo停止
				// Controlword(Index:0x6040-0x00)へShutdownコマンド(0x0006)を送信する
				send_RSDO((uint)nud_trq_nodeID.Value, IDX_CONTROL_WORD, 0x0006);
			}
		}


		/// <summary>
		/// スライダーのトルク指令値を反映させる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tbar_target_torque_Scroll(object sender, EventArgs e)
		{
			double disp_trq = (double)(tbar_target_torque.Value / 10.0);
			nud_target_torque.Value = (decimal)disp_trq;
		}


		/// <summary>
		/// トルク指令値の変更に合わせてRoboservoに指令値を送信する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void nud_target_torque_ValueChanged(object sender, EventArgs e)
		{
			// 出力トルクの指令値を0.1%単位で指定する
			// 例) 出力トルク 25% = 指令値 250
			int compar_value = (int)(nud_target_torque.Value * 10);
			if (compar_value < tbar_target_torque.Minimum)
			{
				nud_target_torque.Value = tbar_target_torque.Minimum;
			}
			else if (compar_value > tbar_target_torque.Maximum)
			{
				nud_target_torque.Value = tbar_target_torque.Maximum;
			}

			int input_trq = (int)nud_target_torque.Value * 10;
			tbar_target_torque.Value = input_trq;

			// Target Torque(Index:0x6071-0x00)へ出力トルクの指令値を送信する
			send_RSDO((uint)nud_trq_nodeID.Value, IDX_TARGET_TORQUE, (uint)tbar_target_torque.Value);
		}



		/************************************************************************************/
		/*	Tab : Velocity control															*/
		/************************************************************************************/

		/// <summary>
		/// Roboservoを速度制御モードで起動する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_velo_OnOff_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			nud_target_velo.Value = (decimal)0.0;    // 目標速度を0.0[rpm]に設定

			if (button.Text == "トルク　OFF")
			{
				// 制御モードを変更する為に、Controlword(Index:0x6040-0x00)へShutdownコマンド(0x0006)を送信する
				if (send_RSDO((uint)nud_velo_nodeID.Value, IDX_CONTROL_WORD, 0x0006) == true)
				{
					// 制御モード変更
					// Modes of Operation(Index:0x6060-0x00)へProfile velocity mode(0x03)を送信する
					if (send_RSDO((uint)nud_velo_nodeID.Value, IDX_OPERATION_MODE, 0x03) == true)
					{
						// Controlword(Index:0x6040-0x00)へShutdownコマンド(0x0006)を送信する
						if (send_RSDO((uint)nud_velo_nodeID.Value, IDX_CONTROL_WORD, 0x0006) == true)
						{
							// Controlword(Index:0x6040-0x00)へEnable operationコマンド(0x000F) + haltフラグ(0x0100)を送信する
							if (send_RSDO((uint)nud_velo_nodeID.Value, IDX_CONTROL_WORD, 0x010F) == true)
							{
								// Roboservoの起動完了
								button.Text = "トルク　ON";
								button.BackColor = Color.Yellow;

								// 回転開始ボタンを有効化
								btn_velo_StartStop.Enabled = true;
								btn_velo_StartStop.Text = "回転停止";
								btn_velo_StartStop.BackColor = Color.Transparent;
							}
						}

					}
				}
			}
			else
			{
				button.Text = "トルク　OFF";
				button.BackColor = Color.Transparent;

				// Roboservo停止
				// Controlword(Index:0x6040-0x00)へShutdownコマンド(0x0006)を送信する
				send_RSDO((uint)nud_velo_nodeID.Value, IDX_CONTROL_WORD, 0x0006);

				// 回転開始ボタンを無効化
				btn_velo_StartStop.Enabled = false;
				btn_velo_StartStop.Text = "回転停止";
				btn_velo_StartStop.BackColor = Color.Transparent;
			}
		}


		/// <summary>
		/// 速度制御の動作許可
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_velo_StartStop_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			if (button.Text == "回転停止")
			{
				// Profile acceleration(Index:0x6083-0x00)へ加速度指令値を送信する
				if (send_RSDO((uint)nud_velo_nodeID.Value, IDX_PROFILE_ACCELERATION, (uint)(nud_velo_accel.Value * 10)) == true)
				{
					// Profile deceleration(Index:0x6084-0x00)へ減速度指令値を送信する
					if (send_RSDO((uint)nud_velo_nodeID.Value, IDX_PROFILE_DECELERATION, (uint)(nud_velo_decel.Value * 10)) == true)
					{
						// Controlword(Index:0x6040-0x00)へSwitch ON +Enable operationコマンド(0x000F)を送信する
						if (send_RSDO((uint)nud_velo_nodeID.Value, IDX_CONTROL_WORD, 0x000F) == true)
						{
							// 回転開始
							button.Text = "回転開始";
							button.BackColor = Color.Yellow;
						}
					}

				}
			}
			else
			{
				// 回転停止
				button.Text = "回転停止";
				button.BackColor = Color.Transparent;

				// Controlword(Index:0x6040-0x00)へEnable operationコマンド(0x000F) + haltフラグ(0x0100)を送信する
				send_RSDO((uint)nud_velo_nodeID.Value, IDX_CONTROL_WORD, 0x010F);
			}
		}


		/// <summary>
		/// 目標速度の変更に合わせてRoboservoに指令値を送信する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void nud_target_velo_ValueChanged(object sender, EventArgs e)
		{
			// 指令値の範囲確認
			int compar_value = (int)(nud_target_velo.Value * 10);
			if (compar_value < tbar_velocity.Minimum)
			{
				nud_target_velo.Value = (decimal)((double)tbar_velocity.Minimum / 10);
			}
			else if (compar_value > tbar_velocity.Maximum)
			{
				nud_target_velo.Value = (decimal)((double)tbar_velocity.Maximum / 10);
			}

			// 目標速度の指令値を0.1%単位で指定する
			// 例) 目標速度 16.0[rpm] = 指令値 160
			int input_velo = (int)(nud_target_velo.Value * 10);
			tbar_velocity.Value = input_velo;

			// Target Velocity(Index:0x60FF-0x00)へ目標速度の指令値を送信する
			send_RSDO((uint)nud_velo_nodeID.Value, IDX_TARGET_VELOCITY, (uint)tbar_velocity.Value);
		}


		/// <summary>
		/// スライダーの目標速度を反映させる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tbar_velocity_Scroll(object sender, EventArgs e)
		{
			double disp_velo = (double)(tbar_velocity.Value / 10.0);
			nud_target_velo.Value = (decimal)disp_velo;
		}



		/************************************************************************************/
		/*	Tab : Position control															*/
		/************************************************************************************/

		/// <summary>
		/// Roboservoを位置制御モード起動する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_posi_OnOff_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			nud_target_posi.Value = (decimal)0.0;    // 目標位置を0.0[deg]に設定

			if (button.Text == "トルク　OFF")
			{
				// 制御モードを変更する為に、Controlword(Index:0x6040-0x00)へShutdownコマンド(0x0006)を送信する
				if (send_RSDO((uint)nud_posi_nodeID.Value, IDX_CONTROL_WORD, 0x0006) == true)
				{
					// 制御モード変更
					// Modes of Operation(Index:0x6060-0x00)へProfile position mode(0x01)を送信する
					if (send_RSDO((uint)nud_posi_nodeID.Value, IDX_OPERATION_MODE, 0x01) == true)
					{
						// Controlword(Index:0x6040-0x00)へShutdownコマンド(0x0006)を送信する
						if (send_RSDO((uint)nud_posi_nodeID.Value, IDX_CONTROL_WORD, 0x0006) == true)
						{
							// Controlword(Index:0x6040-0x00)へSwitch ON +Enable operationコマンド(0x000F)を送信する
							if (send_RSDO((uint)nud_posi_nodeID.Value, IDX_CONTROL_WORD, 0x000F) == true)
							{
								// Actual position(Index:0x6064-0x00)から現在位置を読み出す
								uint read_data = 0;
								send_TSDO((uint)nud_posi_nodeID.Value, IDX_ACTUAL_POSITION, out read_data);
								int enc_data = (int)read_data;
								double actual_posi = (double)enc_data / A_ROUND_ENC_CNT * 360.0;
								nud_actual_posi.Value = (decimal)actual_posi;
								
								// Roboservoの起動完了
								button.Text = "トルク　ON";
								button.BackColor = Color.Yellow;
								
								// 移動開始ボタンを有効化
								btn_posi_StartStop.Enabled = true;
								btn_posi_StartStop.Text = "移動停止";
								btn_posi_StartStop.BackColor = Color.Transparent;
							}
						}

					}
				}
			}
			else
			{
				button.Text = "トルク　OFF";
				button.BackColor = Color.Transparent;

				// Roboservo停止
				// Controlword(Index:0x6040-0x00)へShutdownコマンド(0x0006)を送信する
				send_RSDO((uint)nud_posi_nodeID.Value, IDX_CONTROL_WORD, 0x0006);

				// 移動開始ボタンを無効化
				btn_posi_StartStop.Enabled = false;
				btn_posi_StartStop.Text = "移動停止";
				btn_posi_StartStop.BackColor = Color.Transparent;
			}
		}


		/// <summary>
		/// 位置制御の動作許可
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_posi_StartStop_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			if (button.Text == "移動停止")
			{
				// Profile velocity(Index:0x6081-0x00)へ加速度指令値を送信する
				if (send_RSDO((uint)nud_posi_nodeID.Value, IDX_PROFILE_VELOCITY, (uint)(nud_posi_velo.Value * 10)) == true)
				{
					// Profile acceleration(Index:0x6083-0x00)へ加速度指令値を送信する
					if (send_RSDO((uint)nud_posi_nodeID.Value, IDX_PROFILE_ACCELERATION, (uint)(nud_posi_accel.Value * 10)) == true)
					{
						// Profile deceleration(Index:0x6084-0x00)へ減速度指令値を送信する
						if (send_RSDO((uint)nud_posi_nodeID.Value, IDX_PROFILE_DECELERATION, (uint)(nud_posi_decel.Value * 10)) == true)
						{
							// Controlword(Index:0x6040-0x00)へEnable operationコマンド(0x000F) + 動作開始フラグ(0x0030)を送信する
							if (send_RSDO((uint)nud_posi_nodeID.Value, IDX_CONTROL_WORD, 0x003F) == true)
							{
								// 移動開始
								button.Text = "移動開始";
								button.BackColor = Color.Yellow;

								tim_param_read.Start();
							}
						}
					}
				}
			}
			else
			{
				// 移動停止
				button.Text = "移動停止";
				button.BackColor = Color.Transparent;

				// Controlword(Index:0x6040-0x00)へEnable operationコマンド(0x000F) + haltフラグ(0x0100)を送信する
				send_RSDO((uint)nud_posi_nodeID.Value, IDX_CONTROL_WORD, 0x010F);

				tim_param_read.Stop();
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void nud_target_posi_ValueChanged(object sender, EventArgs e)
		{
			// 指令値の範囲確認
			int compar_value = (int)(nud_target_posi.Value * 10);
			if (compar_value < tbar_target_posi.Minimum)
			{
				nud_target_posi.Value = (decimal)((double)tbar_target_posi.Minimum / 10.0);
			}
			else if (compar_value > tbar_target_posi.Maximum)
			{
				nud_target_posi.Value = (decimal)((double)tbar_target_posi.Maximum / 10.0);
			}
			tbar_target_posi.Value = (int)(nud_target_posi.Value * 10);

			// 目標位置の指令値を0.1度単位で指定する(出力軸エンコーダの値で指定する)
			// 1回転のエンコーダ値は 0x40000
			// 例) 目標位置 90.0[deg] = 指令値 (90.0 / 360.0) * 0x40000
			uint target_posi = (uint)(((double)nud_target_posi.Value / 360.0) * A_ROUND_ENC_CNT);

			// Target position(Index:0x607A-0x00)へ目標位置の指令値を送信する
			send_RSDO((uint)nud_posi_nodeID.Value, IDX_TARGET_POSITION, target_posi);

			// 移動可能な場合、目標位置へ移動開始
			if(btn_posi_StartStop.BackColor == Color.Yellow)
			{
				// Controlword(Index:0x6040-0x00)へEnable operationコマンド(0x000F)を送信する
				send_RSDO((uint)nud_posi_nodeID.Value, IDX_CONTROL_WORD, 0x000F);
				// Controlword(Index:0x6040-0x00)へEnable operationコマンド(0x000F) + 動作開始フラグ(0x0030)を送信する
				send_RSDO((uint)nud_posi_nodeID.Value, IDX_CONTROL_WORD, 0x003F);
			}
		}


		/// <summary>
		/// スライダーの目標位置を反映させる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tbar_target_posi_Scroll(object sender, EventArgs e)
		{
			double disp_deg = (double)(tbar_target_posi.Value / 10.0);
			nud_target_posi.Value = (decimal)disp_deg;
		}


		/// <summary>
		/// 現在位置の読出し
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tim_param_read_Tick(object sender, EventArgs e)
		{
			if(btn_posi_StartStop.BackColor == Color.Yellow)
			{
				// Actual position(Index:0x6064-0x00)から現在位置を読み出す
				uint read_data = 0;
				if (send_TSDO((uint)nud_posi_nodeID.Value, IDX_ACTUAL_POSITION, out read_data) == true)
				{
					// 読出しデータ(出力軸エンコーダ値)を角度[deg]へ変換する
					// 1回転のエンコーダ値は 0x40000
					// 例) 現在位置 1800.0[deg] = エンコーダ値 (0x20000 / 0x40000) * 360.0
					int enc_data = (int)read_data;
					double actual_posi = (double)enc_data / A_ROUND_ENC_CNT * 360.0;
					nud_actual_posi.Value = (decimal)actual_posi;
				}
			}
		}
	}
}
