namespace CANopen_ctrl_app
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_connect = new System.Windows.Forms.Button();
			this.cbb_bitrate_sel = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbb_hardware_sel = new System.Windows.Forms.ComboBox();
			this.tabc_controls = new System.Windows.Forms.TabControl();
			this.tab_param = new System.Windows.Forms.TabPage();
			this.label7 = new System.Windows.Forms.Label();
			this.btn_node_scan = new System.Windows.Forms.Button();
			this.tb_connecting_node = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.nud_nodeID_after = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btn_param_restore = new System.Windows.Forms.Button();
			this.btn_param_save = new System.Windows.Forms.Button();
			this.btn_param_send = new System.Windows.Forms.Button();
			this.btn_reboot = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.nud_nodeID_before = new System.Windows.Forms.NumericUpDown();
			this.tab_torque = new System.Windows.Forms.TabPage();
			this.nud_target_torque = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.tbar_target_torque = new System.Windows.Forms.TrackBar();
			this.btn_trq_switch = new System.Windows.Forms.Button();
			this.label29 = new System.Windows.Forms.Label();
			this.nud_trq_nodeID = new System.Windows.Forms.NumericUpDown();
			this.tab_velocity = new System.Windows.Forms.TabPage();
			this.nud_velo_decel = new System.Windows.Forms.NumericUpDown();
			this.nud_velo_accel = new System.Windows.Forms.NumericUpDown();
			this.nud_target_velo = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.btn_velo_StartStop = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tbar_velocity = new System.Windows.Forms.TrackBar();
			this.btn_velo_OnOff = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.nud_velo_nodeID = new System.Windows.Forms.NumericUpDown();
			this.tab_position = new System.Windows.Forms.TabPage();
			this.nud_actual_posi = new System.Windows.Forms.NumericUpDown();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.nud_posi_decel = new System.Windows.Forms.NumericUpDown();
			this.nud_posi_accel = new System.Windows.Forms.NumericUpDown();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.nud_posi_velo = new System.Windows.Forms.NumericUpDown();
			this.nud_target_posi = new System.Windows.Forms.NumericUpDown();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.btn_posi_StartStop = new System.Windows.Forms.Button();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.tbar_target_posi = new System.Windows.Forms.TrackBar();
			this.btn_posi_OnOff = new System.Windows.Forms.Button();
			this.label26 = new System.Windows.Forms.Label();
			this.nud_posi_nodeID = new System.Windows.Forms.NumericUpDown();
			this.tim_param_read = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.tabc_controls.SuspendLayout();
			this.tab_param.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_nodeID_after)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_nodeID_before)).BeginInit();
			this.tab_torque.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_target_torque)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_target_torque)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_trq_nodeID)).BeginInit();
			this.tab_velocity.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_velo_decel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_velo_accel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_target_velo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_velocity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_velo_nodeID)).BeginInit();
			this.tab_position.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_actual_posi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_posi_decel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_posi_accel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_posi_velo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_target_posi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_target_posi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_posi_nodeID)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btn_connect);
			this.groupBox1.Controls.Add(this.cbb_bitrate_sel);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cbb_hardware_sel);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(960, 90);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Interface";
			// 
			// btn_connect
			// 
			this.btn_connect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_connect.BackColor = System.Drawing.Color.Red;
			this.btn_connect.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btn_connect.Location = new System.Drawing.Point(357, 21);
			this.btn_connect.Name = "btn_connect";
			this.btn_connect.Size = new System.Drawing.Size(581, 48);
			this.btn_connect.TabIndex = 4;
			this.btn_connect.Text = "Disconnected";
			this.btn_connect.UseVisualStyleBackColor = false;
			this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
			// 
			// cbb_bitrate_sel
			// 
			this.cbb_bitrate_sel.FormattingEnabled = true;
			this.cbb_bitrate_sel.Items.AddRange(new object[] {
            "1 MBit/sec",
            "800 kBit/s",
            "500 kBit/sec",
            "250 kBit/sec",
            "125 kBit/sec",
            "100 kBit/sec",
            "95,238 kBit/s",
            "83,333 kBit/s",
            "50 kBit/sec",
            "47,619 kBit/s",
            "33,333 kBit/s",
            "20 kBit/sec",
            "10 kBit/sec",
            "5 kBit/sec"});
			this.cbb_bitrate_sel.Location = new System.Drawing.Point(186, 46);
			this.cbb_bitrate_sel.Name = "cbb_bitrate_sel";
			this.cbb_bitrate_sel.Size = new System.Drawing.Size(152, 23);
			this.cbb_bitrate_sel.TabIndex = 3;
			this.cbb_bitrate_sel.SelectedIndexChanged += new System.EventHandler(this.cbb_bitrate_sel_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(183, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Bitrate";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Hardware";
			// 
			// cbb_hardware_sel
			// 
			this.cbb_hardware_sel.FormattingEnabled = true;
			this.cbb_hardware_sel.Items.AddRange(new object[] {
            "PCAN-USB"});
			this.cbb_hardware_sel.Location = new System.Drawing.Point(18, 46);
			this.cbb_hardware_sel.Name = "cbb_hardware_sel";
			this.cbb_hardware_sel.Size = new System.Drawing.Size(152, 23);
			this.cbb_hardware_sel.TabIndex = 0;
			// 
			// tabc_controls
			// 
			this.tabc_controls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabc_controls.Controls.Add(this.tab_param);
			this.tabc_controls.Controls.Add(this.tab_torque);
			this.tabc_controls.Controls.Add(this.tab_velocity);
			this.tabc_controls.Controls.Add(this.tab_position);
			this.tabc_controls.Location = new System.Drawing.Point(12, 108);
			this.tabc_controls.Name = "tabc_controls";
			this.tabc_controls.SelectedIndex = 0;
			this.tabc_controls.Size = new System.Drawing.Size(960, 616);
			this.tabc_controls.TabIndex = 2;
			// 
			// tab_param
			// 
			this.tab_param.Controls.Add(this.label7);
			this.tab_param.Controls.Add(this.btn_node_scan);
			this.tab_param.Controls.Add(this.tb_connecting_node);
			this.tab_param.Controls.Add(this.label6);
			this.tab_param.Controls.Add(this.nud_nodeID_after);
			this.tab_param.Controls.Add(this.label5);
			this.tab_param.Controls.Add(this.label4);
			this.tab_param.Controls.Add(this.btn_param_restore);
			this.tab_param.Controls.Add(this.btn_param_save);
			this.tab_param.Controls.Add(this.btn_param_send);
			this.tab_param.Controls.Add(this.btn_reboot);
			this.tab_param.Controls.Add(this.label3);
			this.tab_param.Controls.Add(this.nud_nodeID_before);
			this.tab_param.Location = new System.Drawing.Point(4, 25);
			this.tab_param.Name = "tab_param";
			this.tab_param.Size = new System.Drawing.Size(952, 587);
			this.tab_param.TabIndex = 2;
			this.tab_param.Text = "Node-ID setting";
			this.tab_param.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(35, 210);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(369, 180);
			this.label7.TabIndex = 37;
			this.label7.Text = resources.GetString("label7.Text");
			// 
			// btn_node_scan
			// 
			this.btn_node_scan.Location = new System.Drawing.Point(131, 27);
			this.btn_node_scan.Name = "btn_node_scan";
			this.btn_node_scan.Size = new System.Drawing.Size(75, 23);
			this.btn_node_scan.TabIndex = 36;
			this.btn_node_scan.Text = "Scan";
			this.btn_node_scan.UseVisualStyleBackColor = true;
			this.btn_node_scan.Click += new System.EventHandler(this.btn_node_scan_Click);
			// 
			// tb_connecting_node
			// 
			this.tb_connecting_node.Location = new System.Drawing.Point(212, 28);
			this.tb_connecting_node.Name = "tb_connecting_node";
			this.tb_connecting_node.Size = new System.Drawing.Size(214, 22);
			this.tb_connecting_node.TabIndex = 35;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(288, 97);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 15);
			this.label6.TabIndex = 34;
			this.label6.Text = "変更後";
			// 
			// nud_nodeID_after
			// 
			this.nud_nodeID_after.Location = new System.Drawing.Point(346, 95);
			this.nud_nodeID_after.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.nud_nodeID_after.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_nodeID_after.Name = "nud_nodeID_after";
			this.nud_nodeID_after.Size = new System.Drawing.Size(120, 22);
			this.nud_nodeID_after.TabIndex = 33;
			this.nud_nodeID_after.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_nodeID_after.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(250, 97);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(22, 15);
			this.label5.TabIndex = 32;
			this.label5.Text = "⇒";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(35, 97);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 15);
			this.label4.TabIndex = 31;
			this.label4.Text = "変更対象";
			// 
			// btn_param_restore
			// 
			this.btn_param_restore.Location = new System.Drawing.Point(401, 154);
			this.btn_param_restore.Name = "btn_param_restore";
			this.btn_param_restore.Size = new System.Drawing.Size(75, 23);
			this.btn_param_restore.TabIndex = 30;
			this.btn_param_restore.Text = "Restore";
			this.btn_param_restore.UseVisualStyleBackColor = true;
			this.btn_param_restore.Click += new System.EventHandler(this.btn_param_restore_Click);
			// 
			// btn_param_save
			// 
			this.btn_param_save.Location = new System.Drawing.Point(152, 154);
			this.btn_param_save.Name = "btn_param_save";
			this.btn_param_save.Size = new System.Drawing.Size(75, 23);
			this.btn_param_save.TabIndex = 29;
			this.btn_param_save.Text = "Save";
			this.btn_param_save.UseVisualStyleBackColor = true;
			this.btn_param_save.Click += new System.EventHandler(this.btn_param_save_Click);
			// 
			// btn_param_send
			// 
			this.btn_param_send.Location = new System.Drawing.Point(38, 154);
			this.btn_param_send.Name = "btn_param_send";
			this.btn_param_send.Size = new System.Drawing.Size(75, 23);
			this.btn_param_send.TabIndex = 28;
			this.btn_param_send.Text = "Send";
			this.btn_param_send.UseVisualStyleBackColor = true;
			this.btn_param_send.Click += new System.EventHandler(this.btn_param_send_Click);
			// 
			// btn_reboot
			// 
			this.btn_reboot.Location = new System.Drawing.Point(263, 154);
			this.btn_reboot.Name = "btn_reboot";
			this.btn_reboot.Size = new System.Drawing.Size(75, 23);
			this.btn_reboot.TabIndex = 26;
			this.btn_reboot.Text = "Reboot";
			this.btn_reboot.UseVisualStyleBackColor = true;
			this.btn_reboot.Click += new System.EventHandler(this.btn_reboot_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(35, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Active nodes";
			// 
			// nud_nodeID_before
			// 
			this.nud_nodeID_before.Location = new System.Drawing.Point(108, 95);
			this.nud_nodeID_before.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.nud_nodeID_before.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_nodeID_before.Name = "nud_nodeID_before";
			this.nud_nodeID_before.Size = new System.Drawing.Size(120, 22);
			this.nud_nodeID_before.TabIndex = 0;
			this.nud_nodeID_before.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_nodeID_before.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// tab_torque
			// 
			this.tab_torque.Controls.Add(this.nud_target_torque);
			this.tab_torque.Controls.Add(this.label8);
			this.tab_torque.Controls.Add(this.label31);
			this.tab_torque.Controls.Add(this.label30);
			this.tab_torque.Controls.Add(this.tbar_target_torque);
			this.tab_torque.Controls.Add(this.btn_trq_switch);
			this.tab_torque.Controls.Add(this.label29);
			this.tab_torque.Controls.Add(this.nud_trq_nodeID);
			this.tab_torque.Location = new System.Drawing.Point(4, 25);
			this.tab_torque.Name = "tab_torque";
			this.tab_torque.Padding = new System.Windows.Forms.Padding(3);
			this.tab_torque.Size = new System.Drawing.Size(952, 587);
			this.tab_torque.TabIndex = 3;
			this.tab_torque.Text = "Torque control";
			this.tab_torque.UseVisualStyleBackColor = true;
			// 
			// nud_target_torque
			// 
			this.nud_target_torque.DecimalPlaces = 1;
			this.nud_target_torque.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nud_target_torque.Location = new System.Drawing.Point(486, 39);
			this.nud_target_torque.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nud_target_torque.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147418112});
			this.nud_target_torque.Name = "nud_target_torque";
			this.nud_target_torque.Size = new System.Drawing.Size(100, 22);
			this.nud_target_torque.TabIndex = 10;
			this.nud_target_torque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_target_torque.ValueChanged += new System.EventHandler(this.nud_target_torque_ValueChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(40, 235);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(361, 120);
			this.label8.TabIndex = 9;
			this.label8.Text = "トルク制御でRoboservoを操作します。\r\n目標トルクは定格トルクに対して0.1％単位で指定できます。\r\n\r\n【手順】\r\n　①操作するNode-IDを指定\r\n" +
    "　②\"トルク OFF\"ボタンを押してRoboservoを起動\r\n　③スライダー操作または数値変更によって目標トルクを送信\r\n\r\n";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(597, 42);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(22, 15);
			this.label31.TabIndex = 8;
			this.label31.Text = "％";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(413, 42);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(70, 15);
			this.label30.TabIndex = 6;
			this.label30.Text = "目標トルク";
			// 
			// tbar_target_torque
			// 
			this.tbar_target_torque.BackColor = System.Drawing.SystemColors.Window;
			this.tbar_target_torque.Location = new System.Drawing.Point(416, 76);
			this.tbar_target_torque.Maximum = 1000;
			this.tbar_target_torque.Minimum = -1000;
			this.tbar_target_torque.Name = "tbar_target_torque";
			this.tbar_target_torque.Size = new System.Drawing.Size(472, 56);
			this.tbar_target_torque.TabIndex = 5;
			this.tbar_target_torque.Scroll += new System.EventHandler(this.tbar_target_torque_Scroll);
			// 
			// btn_trq_switch
			// 
			this.btn_trq_switch.Location = new System.Drawing.Point(43, 92);
			this.btn_trq_switch.Name = "btn_trq_switch";
			this.btn_trq_switch.Size = new System.Drawing.Size(140, 107);
			this.btn_trq_switch.TabIndex = 4;
			this.btn_trq_switch.Text = "トルク　OFF";
			this.btn_trq_switch.UseVisualStyleBackColor = true;
			this.btn_trq_switch.Click += new System.EventHandler(this.btn_trp_switch_Click);
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(40, 42);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(62, 15);
			this.label29.TabIndex = 3;
			this.label29.Text = "Node-ID";
			// 
			// nud_trq_nodeID
			// 
			this.nud_trq_nodeID.Location = new System.Drawing.Point(108, 40);
			this.nud_trq_nodeID.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.nud_trq_nodeID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_trq_nodeID.Name = "nud_trq_nodeID";
			this.nud_trq_nodeID.Size = new System.Drawing.Size(120, 22);
			this.nud_trq_nodeID.TabIndex = 2;
			this.nud_trq_nodeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_trq_nodeID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// tab_velocity
			// 
			this.tab_velocity.Controls.Add(this.nud_velo_decel);
			this.tab_velocity.Controls.Add(this.nud_velo_accel);
			this.tab_velocity.Controls.Add(this.nud_target_velo);
			this.tab_velocity.Controls.Add(this.label15);
			this.tab_velocity.Controls.Add(this.label16);
			this.tab_velocity.Controls.Add(this.label13);
			this.tab_velocity.Controls.Add(this.label14);
			this.tab_velocity.Controls.Add(this.btn_velo_StartStop);
			this.tab_velocity.Controls.Add(this.label9);
			this.tab_velocity.Controls.Add(this.label10);
			this.tab_velocity.Controls.Add(this.label11);
			this.tab_velocity.Controls.Add(this.tbar_velocity);
			this.tab_velocity.Controls.Add(this.btn_velo_OnOff);
			this.tab_velocity.Controls.Add(this.label12);
			this.tab_velocity.Controls.Add(this.nud_velo_nodeID);
			this.tab_velocity.Location = new System.Drawing.Point(4, 25);
			this.tab_velocity.Name = "tab_velocity";
			this.tab_velocity.Size = new System.Drawing.Size(952, 587);
			this.tab_velocity.TabIndex = 4;
			this.tab_velocity.Text = "Velocity control";
			this.tab_velocity.UseVisualStyleBackColor = true;
			// 
			// nud_velo_decel
			// 
			this.nud_velo_decel.DecimalPlaces = 1;
			this.nud_velo_decel.Location = new System.Drawing.Point(749, 159);
			this.nud_velo_decel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nud_velo_decel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_velo_decel.Name = "nud_velo_decel";
			this.nud_velo_decel.Size = new System.Drawing.Size(100, 22);
			this.nud_velo_decel.TabIndex = 27;
			this.nud_velo_decel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_velo_decel.Value = new decimal(new int[] {
            100,
            0,
            0,
            65536});
			// 
			// nud_velo_accel
			// 
			this.nud_velo_accel.DecimalPlaces = 1;
			this.nud_velo_accel.Location = new System.Drawing.Point(486, 159);
			this.nud_velo_accel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nud_velo_accel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_velo_accel.Name = "nud_velo_accel";
			this.nud_velo_accel.Size = new System.Drawing.Size(100, 22);
			this.nud_velo_accel.TabIndex = 26;
			this.nud_velo_accel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_velo_accel.Value = new decimal(new int[] {
            100,
            0,
            0,
            65536});
			// 
			// nud_target_velo
			// 
			this.nud_target_velo.DecimalPlaces = 1;
			this.nud_target_velo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nud_target_velo.Location = new System.Drawing.Point(486, 39);
			this.nud_target_velo.Maximum = new decimal(new int[] {
            320,
            0,
            0,
            65536});
			this.nud_target_velo.Minimum = new decimal(new int[] {
            320,
            0,
            0,
            -2147418112});
			this.nud_target_velo.Name = "nud_target_velo";
			this.nud_target_velo.Size = new System.Drawing.Size(100, 22);
			this.nud_target_velo.TabIndex = 25;
			this.nud_target_velo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_target_velo.ValueChanged += new System.EventHandler(this.nud_target_velo_ValueChanged);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(855, 161);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(55, 15);
			this.label15.TabIndex = 24;
			this.label15.Text = "[rpm/s]";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(676, 161);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(52, 15);
			this.label16.TabIndex = 22;
			this.label16.Text = "減速度";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(592, 161);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(55, 15);
			this.label13.TabIndex = 21;
			this.label13.Text = "[rpm/s]";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(413, 161);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(52, 15);
			this.label14.TabIndex = 19;
			this.label14.Text = "加速度";
			// 
			// btn_velo_StartStop
			// 
			this.btn_velo_StartStop.Enabled = false;
			this.btn_velo_StartStop.Location = new System.Drawing.Point(210, 92);
			this.btn_velo_StartStop.Name = "btn_velo_StartStop";
			this.btn_velo_StartStop.Size = new System.Drawing.Size(140, 107);
			this.btn_velo_StartStop.TabIndex = 18;
			this.btn_velo_StartStop.Text = "回転停止";
			this.btn_velo_StartStop.UseVisualStyleBackColor = true;
			this.btn_velo_StartStop.Click += new System.EventHandler(this.btn_velo_StartStop_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(40, 235);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(415, 135);
			this.label9.TabIndex = 17;
			this.label9.Text = "速度制御でRoboservoを操作します。\r\n目標速度は0.1 [rpm]単位で指定できます。\r\n\r\n【手順】\r\n　①操作するNode-IDを指定\r\n　②\"トルク" +
    " OFF\"ボタンを押してRoboservoを起動\r\n　③\"回転停止\"ボタンを押して回転を許可 (加速度/減速度も反映)\r\n　④スライダー操作または数値変更によっ" +
    "て目標速度を送信\r\n　⑤\"回転停止(開始)\"ボタンによって一時停止/再開が可能";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(592, 42);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 15);
			this.label10.TabIndex = 16;
			this.label10.Text = "[rpm]";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(413, 42);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(67, 15);
			this.label11.TabIndex = 14;
			this.label11.Text = "目標速度";
			// 
			// tbar_velocity
			// 
			this.tbar_velocity.BackColor = System.Drawing.SystemColors.Window;
			this.tbar_velocity.Location = new System.Drawing.Point(416, 76);
			this.tbar_velocity.Maximum = 320;
			this.tbar_velocity.Minimum = -320;
			this.tbar_velocity.Name = "tbar_velocity";
			this.tbar_velocity.Size = new System.Drawing.Size(472, 56);
			this.tbar_velocity.TabIndex = 13;
			this.tbar_velocity.Scroll += new System.EventHandler(this.tbar_velocity_Scroll);
			// 
			// btn_velo_OnOff
			// 
			this.btn_velo_OnOff.Location = new System.Drawing.Point(43, 92);
			this.btn_velo_OnOff.Name = "btn_velo_OnOff";
			this.btn_velo_OnOff.Size = new System.Drawing.Size(140, 107);
			this.btn_velo_OnOff.TabIndex = 12;
			this.btn_velo_OnOff.Text = "トルク　OFF";
			this.btn_velo_OnOff.UseVisualStyleBackColor = true;
			this.btn_velo_OnOff.Click += new System.EventHandler(this.btn_velo_OnOff_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(40, 42);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(62, 15);
			this.label12.TabIndex = 11;
			this.label12.Text = "Node-ID";
			// 
			// nud_velo_nodeID
			// 
			this.nud_velo_nodeID.Location = new System.Drawing.Point(108, 40);
			this.nud_velo_nodeID.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.nud_velo_nodeID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_velo_nodeID.Name = "nud_velo_nodeID";
			this.nud_velo_nodeID.Size = new System.Drawing.Size(120, 22);
			this.nud_velo_nodeID.TabIndex = 10;
			this.nud_velo_nodeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_velo_nodeID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// tab_position
			// 
			this.tab_position.Controls.Add(this.nud_actual_posi);
			this.tab_position.Controls.Add(this.label19);
			this.tab_position.Controls.Add(this.label20);
			this.tab_position.Controls.Add(this.nud_posi_decel);
			this.tab_position.Controls.Add(this.nud_posi_accel);
			this.tab_position.Controls.Add(this.label17);
			this.tab_position.Controls.Add(this.label18);
			this.tab_position.Controls.Add(this.label27);
			this.tab_position.Controls.Add(this.label28);
			this.tab_position.Controls.Add(this.nud_posi_velo);
			this.tab_position.Controls.Add(this.nud_target_posi);
			this.tab_position.Controls.Add(this.label21);
			this.tab_position.Controls.Add(this.label22);
			this.tab_position.Controls.Add(this.btn_posi_StartStop);
			this.tab_position.Controls.Add(this.label23);
			this.tab_position.Controls.Add(this.label24);
			this.tab_position.Controls.Add(this.label25);
			this.tab_position.Controls.Add(this.tbar_target_posi);
			this.tab_position.Controls.Add(this.btn_posi_OnOff);
			this.tab_position.Controls.Add(this.label26);
			this.tab_position.Controls.Add(this.nud_posi_nodeID);
			this.tab_position.Location = new System.Drawing.Point(4, 25);
			this.tab_position.Name = "tab_position";
			this.tab_position.Size = new System.Drawing.Size(952, 587);
			this.tab_position.TabIndex = 5;
			this.tab_position.Text = "Position control";
			this.tab_position.UseVisualStyleBackColor = true;
			// 
			// nud_actual_posi
			// 
			this.nud_actual_posi.DecimalPlaces = 1;
			this.nud_actual_posi.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nud_actual_posi.Location = new System.Drawing.Point(749, 39);
			this.nud_actual_posi.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.nud_actual_posi.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
			this.nud_actual_posi.Name = "nud_actual_posi";
			this.nud_actual_posi.Size = new System.Drawing.Size(100, 22);
			this.nud_actual_posi.TabIndex = 51;
			this.nud_actual_posi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_actual_posi.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(855, 42);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(39, 15);
			this.label19.TabIndex = 50;
			this.label19.Text = "[deg]";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(676, 42);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(67, 15);
			this.label20.TabIndex = 49;
			this.label20.Text = "現在位置";
			// 
			// nud_posi_decel
			// 
			this.nud_posi_decel.DecimalPlaces = 1;
			this.nud_posi_decel.Location = new System.Drawing.Point(749, 187);
			this.nud_posi_decel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nud_posi_decel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_posi_decel.Name = "nud_posi_decel";
			this.nud_posi_decel.Size = new System.Drawing.Size(100, 22);
			this.nud_posi_decel.TabIndex = 48;
			this.nud_posi_decel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_posi_decel.Value = new decimal(new int[] {
            100,
            0,
            0,
            65536});
			// 
			// nud_posi_accel
			// 
			this.nud_posi_accel.DecimalPlaces = 1;
			this.nud_posi_accel.Location = new System.Drawing.Point(486, 187);
			this.nud_posi_accel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nud_posi_accel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_posi_accel.Name = "nud_posi_accel";
			this.nud_posi_accel.Size = new System.Drawing.Size(100, 22);
			this.nud_posi_accel.TabIndex = 47;
			this.nud_posi_accel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_posi_accel.Value = new decimal(new int[] {
            100,
            0,
            0,
            65536});
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(855, 189);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(55, 15);
			this.label17.TabIndex = 46;
			this.label17.Text = "[rpm/s]";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(676, 189);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(52, 15);
			this.label18.TabIndex = 45;
			this.label18.Text = "減速度";
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(592, 189);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(55, 15);
			this.label27.TabIndex = 44;
			this.label27.Text = "[rpm/s]";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(413, 189);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(52, 15);
			this.label28.TabIndex = 43;
			this.label28.Text = "加速度";
			// 
			// nud_posi_velo
			// 
			this.nud_posi_velo.DecimalPlaces = 1;
			this.nud_posi_velo.Location = new System.Drawing.Point(486, 159);
			this.nud_posi_velo.Maximum = new decimal(new int[] {
            320,
            0,
            0,
            65536});
			this.nud_posi_velo.Minimum = new decimal(new int[] {
            320,
            0,
            0,
            -2147418112});
			this.nud_posi_velo.Name = "nud_posi_velo";
			this.nud_posi_velo.Size = new System.Drawing.Size(100, 22);
			this.nud_posi_velo.TabIndex = 41;
			this.nud_posi_velo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_posi_velo.Value = new decimal(new int[] {
            160,
            0,
            0,
            65536});
			// 
			// nud_target_posi
			// 
			this.nud_target_posi.DecimalPlaces = 1;
			this.nud_target_posi.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nud_target_posi.Location = new System.Drawing.Point(486, 39);
			this.nud_target_posi.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
			this.nud_target_posi.Minimum = new decimal(new int[] {
            720,
            0,
            0,
            -2147483648});
			this.nud_target_posi.Name = "nud_target_posi";
			this.nud_target_posi.Size = new System.Drawing.Size(100, 22);
			this.nud_target_posi.TabIndex = 40;
			this.nud_target_posi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_target_posi.ValueChanged += new System.EventHandler(this.nud_target_posi_ValueChanged);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(592, 161);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(40, 15);
			this.label21.TabIndex = 37;
			this.label21.Text = "[rpm]";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(413, 161);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(52, 15);
			this.label22.TabIndex = 36;
			this.label22.Text = "回転数";
			// 
			// btn_posi_StartStop
			// 
			this.btn_posi_StartStop.Enabled = false;
			this.btn_posi_StartStop.Location = new System.Drawing.Point(210, 92);
			this.btn_posi_StartStop.Name = "btn_posi_StartStop";
			this.btn_posi_StartStop.Size = new System.Drawing.Size(140, 107);
			this.btn_posi_StartStop.TabIndex = 35;
			this.btn_posi_StartStop.Text = "移動停止";
			this.btn_posi_StartStop.UseVisualStyleBackColor = true;
			this.btn_posi_StartStop.Click += new System.EventHandler(this.btn_posi_StartStop_Click);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(40, 235);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(468, 135);
			this.label23.TabIndex = 34;
			this.label23.Text = resources.GetString("label23.Text");
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(592, 42);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(39, 15);
			this.label24.TabIndex = 33;
			this.label24.Text = "[deg]";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(413, 42);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(67, 15);
			this.label25.TabIndex = 32;
			this.label25.Text = "目標位置";
			// 
			// tbar_target_posi
			// 
			this.tbar_target_posi.BackColor = System.Drawing.SystemColors.Window;
			this.tbar_target_posi.Location = new System.Drawing.Point(416, 76);
			this.tbar_target_posi.Maximum = 3600;
			this.tbar_target_posi.Minimum = -3600;
			this.tbar_target_posi.Name = "tbar_target_posi";
			this.tbar_target_posi.Size = new System.Drawing.Size(472, 56);
			this.tbar_target_posi.TabIndex = 31;
			this.tbar_target_posi.Scroll += new System.EventHandler(this.tbar_target_posi_Scroll);
			// 
			// btn_posi_OnOff
			// 
			this.btn_posi_OnOff.Location = new System.Drawing.Point(43, 92);
			this.btn_posi_OnOff.Name = "btn_posi_OnOff";
			this.btn_posi_OnOff.Size = new System.Drawing.Size(140, 107);
			this.btn_posi_OnOff.TabIndex = 30;
			this.btn_posi_OnOff.Text = "トルク　OFF";
			this.btn_posi_OnOff.UseVisualStyleBackColor = true;
			this.btn_posi_OnOff.Click += new System.EventHandler(this.btn_posi_OnOff_Click);
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(40, 42);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(62, 15);
			this.label26.TabIndex = 29;
			this.label26.Text = "Node-ID";
			// 
			// nud_posi_nodeID
			// 
			this.nud_posi_nodeID.Location = new System.Drawing.Point(108, 40);
			this.nud_posi_nodeID.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.nud_posi_nodeID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_posi_nodeID.Name = "nud_posi_nodeID";
			this.nud_posi_nodeID.Size = new System.Drawing.Size(120, 22);
			this.nud_posi_nodeID.TabIndex = 28;
			this.nud_posi_nodeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nud_posi_nodeID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// tim_param_read
			// 
			this.tim_param_read.Tick += new System.EventHandler(this.tim_param_read_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 749);
			this.Controls.Add(this.tabc_controls);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Roboservo sample ver. 0.112";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabc_controls.ResumeLayout(false);
			this.tab_param.ResumeLayout(false);
			this.tab_param.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_nodeID_after)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_nodeID_before)).EndInit();
			this.tab_torque.ResumeLayout(false);
			this.tab_torque.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_target_torque)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_target_torque)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_trq_nodeID)).EndInit();
			this.tab_velocity.ResumeLayout(false);
			this.tab_velocity.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_velo_decel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_velo_accel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_target_velo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_velocity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_velo_nodeID)).EndInit();
			this.tab_position.ResumeLayout(false);
			this.tab_position.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_actual_posi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_posi_decel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_posi_accel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_posi_velo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_target_posi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbar_target_posi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_posi_nodeID)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_hardware_sel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_bitrate_sel;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TabControl tabc_controls;
        private System.Windows.Forms.TabPage tab_param;
		private System.Windows.Forms.Button btn_param_restore;
		private System.Windows.Forms.Button btn_param_save;
		private System.Windows.Forms.Button btn_param_send;
		private System.Windows.Forms.Button btn_reboot;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nud_nodeID_before;
		private System.Windows.Forms.TabPage tab_torque;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TrackBar tbar_target_torque;
		private System.Windows.Forms.Button btn_trq_switch;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.NumericUpDown nud_trq_nodeID;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown nud_nodeID_after;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btn_node_scan;
		private System.Windows.Forms.TextBox tb_connecting_node;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabPage tab_velocity;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TrackBar tbar_velocity;
		private System.Windows.Forms.Button btn_velo_OnOff;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown nud_velo_nodeID;
		private System.Windows.Forms.Button btn_velo_StartStop;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.NumericUpDown nud_target_torque;
		private System.Windows.Forms.NumericUpDown nud_target_velo;
		private System.Windows.Forms.NumericUpDown nud_velo_accel;
		private System.Windows.Forms.NumericUpDown nud_velo_decel;
		private System.Windows.Forms.TabPage tab_position;
		private System.Windows.Forms.NumericUpDown nud_posi_velo;
		private System.Windows.Forms.NumericUpDown nud_target_posi;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button btn_posi_StartStop;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TrackBar tbar_target_posi;
		private System.Windows.Forms.Button btn_posi_OnOff;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.NumericUpDown nud_posi_nodeID;
		private System.Windows.Forms.NumericUpDown nud_posi_decel;
		private System.Windows.Forms.NumericUpDown nud_posi_accel;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.NumericUpDown nud_actual_posi;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Timer tim_param_read;
	}
}

