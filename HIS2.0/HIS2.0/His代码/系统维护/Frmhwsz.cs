using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
namespace ts_yp_xtwh
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmhwsz : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtdm;
        private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Button butquit;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.Button butprint;
        private GroupBox groupBox3;
        private GroupBox groupBox1;
        private ComboBox cmbjx;
        private Label label3;
        private ComboBox cmbyplx;
        private Label label2;
        private CheckBox checkBox1;
        private DataGridTextBoxColumn dataGridTextBoxColumn9;
        private ComboBox cmbyjks;
        private Label label4;
        private CheckBox checkBox2;
        private DataGridTextBoxColumn dataGridTextBoxColumn10;
        private TextBox txthw;
        private Label label5;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        public Frmhwsz(MenuTag menuTag, string chineseName, Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            if (menuTag.Function_Name=="Fun_ts_yp_xtwh_kwsz")
                 Yp.AddcmbYjks(cmbyjks,DeptType.药库, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
            else
                 Yp.AddcmbYjks(cmbyjks, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

            if (InstanceForm.BCurrentUser.IsAdministrator == false) { cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId; cmbyjks.Enabled = false; }

            Yp.AddCmbYplx(true, Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")), cmbyplx, InstanceForm.BDatabase);
            Yp.AddcmbYpjx(true, Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")), cmbjx, InstanceForm.BDatabase);
            cmbyplx.Text = "全部";
            cmbjx.Text = "全部";

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txthw = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cmbjx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 454);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(866, 31);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 300;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 1001;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 21);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(860, 317);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.myKeyDown += new myDataGrid.myDelegate(this.myDataGrid1_myKeyDown);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn10});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "剂型";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "商品名";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "库存量";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 66;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "单位";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 50;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "货位编号";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 150;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "GGID";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 0;
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(1013, 21);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(128, 41);
            this.butprint.TabIndex = 6;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(1013, 62);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(128, 41);
            this.butquit.TabIndex = 4;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(875, 62);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(128, 41);
            this.butsave.TabIndex = 2;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // txtdm
            // 
            this.txtdm.Location = new System.Drawing.Point(693, 62);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(128, 27);
            this.txtdm.TabIndex = 1;
            this.txtdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdm_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(608, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找药品";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txthw);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.cmbyjks);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.cmbjx);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmbyplx);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtdm);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.butprint);
            this.groupBox3.Controls.Add(this.butquit);
            this.groupBox3.Controls.Add(this.butsave);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(866, 113);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询";
            // 
            // txthw
            // 
            this.txthw.Location = new System.Drawing.Point(693, 21);
            this.txthw.Name = "txthw";
            this.txthw.Size = new System.Drawing.Size(128, 27);
            this.txthw.TabIndex = 16;
            this.txthw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdm_KeyUp);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(608, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "查找货位";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(469, 21);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(102, 22);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.Text = "有库存的";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbyjks.FormattingEnabled = true;
            this.cmbyjks.Location = new System.Drawing.Point(107, 21);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(160, 25);
            this.cmbyjks.TabIndex = 13;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(19, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "药剂科室";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(277, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(174, 22);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "已设置库位的药品";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // cmbjx
            // 
            this.cmbjx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbjx.FormattingEnabled = true;
            this.cmbjx.Location = new System.Drawing.Point(359, 62);
            this.cmbjx.Name = "cmbjx";
            this.cmbjx.Size = new System.Drawing.Size(160, 25);
            this.cmbjx.TabIndex = 10;
            this.cmbjx.SelectedIndexChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(275, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "药品剂型";
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbyplx.FormattingEnabled = true;
            this.cmbyplx.Location = new System.Drawing.Point(107, 62);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(160, 25);
            this.cmbyplx.TabIndex = 8;
            this.cmbyplx.SelectedIndexChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "药品类型";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myDataGrid1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 341);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "库位设置信息";
            // 
            // Frmhwsz
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(866, 485);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusBar1);
            this.Name = "Frmhwsz";
            this.Text = "货位号设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmsccj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]


		private void Frmsccj_Load(object sender, System.EventArgs e)
		{
			try
			{
				//初始化
				DataTable myTb=new DataTable();
			
				for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
				{	
					if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
						myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.Int16"));	
					else
						myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText="";
				}
			
				this.AddData(0,0,"",checkBox1.Checked,checkBox2.Checked,txthw.Text.Trim());


			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void AddData(int yplx,int ypjx,string dm,bool bszkw,bool bkc,string hwmc)
		{

            if (cmbyjks.SelectedValue.ToString() == "System.Data.DataRowView") return;
			DataTable myTb=new DataTable();
			string ssql="";
            int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));


            ssql = @"SELECT '' 序号,dbo.fun_yp_ypjx(ypjx) 剂型,YPPM 品名,ypspm 商品名,ypgg 规格,kcl 库存量,dbo.fun_yp_ypdw(a.ypdw) 单位," +
                  "  hwmc 货位编号,A.GGID FROM YP_YPGGD A  ";

            if (bkc == true)
                ssql = ssql + "  inner join  ";
            else
                ssql = ssql + " left join ";
            ssql = ssql + "   (SELECT GGID,cast(sum(KCL/DWBL) as float)  KCL FROM " + Yp.Seek_kcmx_table(deptid, InstanceForm.BDatabase) + " where  deptid=" + deptid + " GROUP BY GGID) b " +
                  "  ON A.GGID=B.GGID  ";

            
            if (bszkw==true || txthw.Text.Trim()!="")
                ssql=ssql+"  inner join  ";
            else 
                ssql=ssql+" left join ";

             ssql=ssql+"   YP_HWSZ C ON    A.GGID=C.GGID and C.deptid="+deptid+"";

             ssql = ssql + " WHERE A.BDELETE=0 ";

             ssql = ssql + " and ypzlx in(select ypzlx from yp_gllx where deptid=" + deptid + ") ";

            if (yplx > 0)
                ssql = ssql + " and yplx="+yplx+"";
            if (ypjx > 0)
                ssql = ssql + " and ypjx="+ypjx+"";
            
            if (dm != "")
                ssql = ssql + " and a.ggid in(select ggid from yp_ypbm where ypbm like '%" + txtdm.Text.Trim() + "%' or pym like '%" + txtdm.Text.Trim() + "%' or wbm like '%" + txtdm.Text.Trim() + "%' ) ";
            if (hwmc.Trim() != "")
                ssql = ssql + " and hwmc like '%"+hwmc+"%'";

            
            ssql = ssql + " order by hwmc,yplx,ypjx";
			myTb=InstanceForm.BDatabase.GetDataTable(ssql);
			FunBase.AddRowtNo(myTb);
			myTb.TableName="Tb";
			this.myDataGrid1.DataSource=myTb;
			this.myDataGrid1.TableStyles[0].MappingName ="Tb";
            myTb.AcceptChanges();
		}

		private bool myDataGrid1_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			try
			{

				DataTable tb=(DataTable)this.myDataGrid1.DataSource ;
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				int ncol=this.myDataGrid1.CurrentCell.ColumnNumber;
				int nkey=Convert.ToInt32(keyData);
				string columnName=this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].HeaderText.Trim();
				if (nrow>tb.Rows.Count-1) return true;
                //if (columnName.Trim()=="名称" && nkey==13)
                //{
                //    string coltext="";
                //    DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                //    coltext=txtCol.TextBox.Text;
                //    if (coltext.Trim()=="") return true;

                //    if (nrow>=tb.Rows.Count-1)
                //    {
                //        DataRow row=tb.NewRow();
                //        row["序号"]=nrow+2;
                //        tb.Rows.Add(row);
                //    }

                //    tb.Rows[nrow]["名称"]=coltext;
                //    tb.Rows[nrow]["拼音码"]=PubStaticFun.GetPYWBM(coltext,0);
                //    tb.Rows[nrow]["五笔码"]=PubStaticFun.GetPYWBM(coltext,1);
                //}
				if (nkey==13 && columnName=="货位编号")
					this.myDataGrid1.CurrentCell=new DataGridCell(nrow+1,7);

			}
			catch(System.Exception err)
			{
				MessageBox.Show("错误"+err.Message );
			}
			return false;
		}

		private void txtdm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				this.AddData(Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue,"0")),Convert.ToInt32(Convertor.IsNull(cmbjx.SelectedValue,"0")),txtdm.Text.Trim(),checkBox1.Checked,checkBox2.Checked,txthw.Text.Trim());
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}



		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butsave_Click(object sender, System.EventArgs e)
		{


			try
			{
				this.butsave.Enabled=false;
				InstanceForm.BDatabase.BeginTransaction();

				string ssql="";
				string hwmc="";
                int ggid = 0;
                int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
                string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
                    if ( tb.Rows[i].RowState == DataRowState.Unchanged )
                        continue;

					hwmc=tb.Rows[i]["货位编号"].ToString();
					ggid=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["ggid"],"0"));

                    if (hwmc.Trim() != "")
                    {
                        ssql = "select * from yp_hwsz where deptid=" + deptid + " and ggid=" + ggid + " and bscbz=0";
                        DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tab.Rows.Count == 0)
                            ssql = "insert into YP_HWSZ(GGID,HWMC,DEPTID,DJSJ,DJY) values(" + ggid + ",'" + hwmc + "'," + deptid + ",'" + _sDate + "'," + InstanceForm.BCurrentUser.EmployeeId + ") ";
                        else
                            ssql = "update YP_HWSZ set HWMC='" + hwmc + "' where ggid=" + ggid + " and deptid=" + deptid + " ";
                    }
                    else
                        ssql = "delete yp_hwsz where deptid="+deptid+" and ggid="+ggid+" and bscbz=0 ";
					
                    InstanceForm.BDatabase.DoCommand(ssql);
					
				}

				InstanceForm.BDatabase.CommitTransaction();
				MessageBox.Show("保存成功");
				this.butsave.Enabled=true;
                this.AddData(Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")), Convert.ToInt32(Convertor.IsNull(cmbjx.SelectedValue, "0")), txtdm.Text.Trim(), checkBox1.Checked,checkBox2.Checked,txthw.Text.Trim());
			}
			catch(System.Exception err)
			{
				
				this.butsave.Enabled=true;
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				#region 简单打印

				this.butprint.Enabled=false;

				Excel.Application myExcel = new Excel.Application( ) ;

				myExcel.Application.Workbooks.Add (true ) ;
			
				//查询条件
				string swhere="";

				//写入行头
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				int SumRowCount=tb.Rows.Count;
				int SumColCount=0;

				for(int j=0;j<this.myDataGrid1.TableStyles[0].GridColumnStyles.Count;j++)
				{
					if (this.myDataGrid1.TableStyles[0].GridColumnStyles[j].Width>0)
					{
						SumColCount=SumColCount+1;
						myExcel.Cells[5,SumColCount]=this.myDataGrid1.TableStyles[0].GridColumnStyles[j].HeaderText.Trim() ;
					}
				
				}
				myExcel.get_Range(myExcel.Cells[5,1],myExcel.Cells[5,SumColCount]).Font.Bold = true;
				myExcel.get_Range(myExcel.Cells[5,1],myExcel.Cells[5,SumColCount]).Font.Size = 10;


				//逐行写入数据，
				
				for(int i=0;i<tb.Rows.Count;i++)
				{
					int ncol=0;
					for(int j=0;j<tb.Columns.Count;j++)
					{
						if (this.myDataGrid1.TableStyles[0].GridColumnStyles[j].Width>0)
						{
							ncol=ncol+1;
							myExcel.Cells[6+i,ncol]="'"+tb.Rows[i][j].ToString().Trim();
							
						}
					}
				}

				//设置报表表格为最适应宽度
				myExcel.get_Range(myExcel.Cells[6,1],myExcel.Cells[5+SumRowCount,SumColCount]).Select();
				myExcel.get_Range(myExcel.Cells[6,1],myExcel.Cells[5+SumRowCount,SumColCount]).Columns.AutoFit();
				
				//加边框
				myExcel.get_Range(myExcel.Cells[5,1],myExcel.Cells[5+SumRowCount,SumColCount]).Borders.LineStyle = 1;

				//报表名称
				myExcel.Cells[1,1]=cmbyjks.Text.Trim()+"货位列表";
				myExcel.get_Range(myExcel.Cells[1,1],myExcel.Cells[1,SumColCount]).Font.Bold = true;
				myExcel.get_Range(myExcel.Cells[1,1],myExcel.Cells[1,SumColCount]).Font.Size = 16;
				//报表名称跨行居中
				myExcel.get_Range(myExcel.Cells[1,1],myExcel.Cells[1,SumColCount]).Select();
				myExcel.get_Range(myExcel.Cells[1,1],myExcel.Cells[1,SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

				//报表条件
				myExcel.Cells[3,1]=swhere.Trim();
				myExcel.get_Range(myExcel.Cells[3,1],myExcel.Cells[3,SumColCount]).Font.Size = 10;
				myExcel.get_Range(myExcel.Cells[3,1],myExcel.Cells[3,SumColCount]).Select();
				myExcel.get_Range(myExcel.Cells[3,1],myExcel.Cells[5,SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

				//最后一行为黄色
				//myExcel.get_Range(myExcel.Cells[5+SumRowCount,1],myExcel.Cells[5+SumRowCount,SumColCount]).Interior.ColorIndex = 19;
			

				//让Excel文件可见
				myExcel.Visible=true;
				this.butprint.Enabled=true;

				#endregion 
			}
			catch(System.Exception err)
			{
				this.butprint.Enabled=true;
				MessageBox.Show(err.Message);
			}
		}

        private void cmbyplx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbyplx.SelectedValue == null) return;
            if (cmbjx.SelectedValue == null) return;
            if (cmbyplx.SelectedValue.ToString() == "System.Data.DataRowView") return;
            if (cmbjx.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Control control = (Control)sender;
            if (control.Name == "cmbyjks") 
            Yp.AddCmbYplx(true, Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")), cmbyplx, InstanceForm.BDatabase);
            this.AddData(Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")), Convert.ToInt32(Convertor.IsNull(cmbjx.SelectedValue, "0")), txtdm.Text.Trim(), checkBox1.Checked, checkBox2.Checked,txthw.Text.Trim());
        }


	}
}
