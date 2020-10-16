namespace cal_endar
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.add = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fname = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.TextBox();
            this.addpeople = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listpeoplelistbox = new System.Windows.Forms.ListBox();
            this.drop = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.CausesValidation = false;
            this.add.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(28, 9);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(157, 32);
            this.add.TabIndex = 0;
            this.add.Text = "اضافه کردن ";
            this.add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.add.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label1
            // 
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.label1.Location = new System.Drawing.Point(28, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام خانوادگی";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.CausesValidation = false;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(28, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "نام";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.Label1_Click);
            // 
            // fname
            // 
            this.fname.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.fname.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.fname.Location = new System.Drawing.Point(33, 83);
            this.fname.Multiline = true;
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(157, 20);
            this.fname.TabIndex = 1;
            this.fname.Text = "هوره";
            this.fname.TextChanged += new System.EventHandler(this.Fname_TextChanged);
            // 
            // lname
            // 
            this.lname.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lname.Location = new System.Drawing.Point(33, 132);
            this.lname.Multiline = true;
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(157, 20);
            this.lname.TabIndex = 1;
            this.lname.Text = "امامقلی";
            this.lname.TextChanged += new System.EventHandler(this.Lname_TextChanged);
            // 
            // addpeople
            // 
            this.addpeople.BackColor = System.Drawing.Color.ForestGreen;
            this.addpeople.Font = new System.Drawing.Font("Haettenschweiler", 9.75F);
            this.addpeople.ForeColor = System.Drawing.Color.Transparent;
            this.addpeople.Location = new System.Drawing.Point(33, 163);
            this.addpeople.Name = "addpeople";
            this.addpeople.Size = new System.Drawing.Size(70, 26);
            this.addpeople.TabIndex = 2;
            this.addpeople.Text = "اضافه کردن";
            this.addpeople.UseVisualStyleBackColor = false;
            this.addpeople.Click += new System.EventHandler(this.Addpeople_Click);
            // 
            // label3
            // 
            this.label3.CausesValidation = false;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "لیست افراد";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.Label1_Click);
            // 
            // listpeoplelistbox
            // 
            this.listpeoplelistbox.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.listpeoplelistbox.FormattingEnabled = true;
            this.listpeoplelistbox.ItemHeight = 18;
            this.listpeoplelistbox.Location = new System.Drawing.Point(212, 59);
            this.listpeoplelistbox.Name = "listpeoplelistbox";
            this.listpeoplelistbox.Size = new System.Drawing.Size(168, 76);
            this.listpeoplelistbox.TabIndex = 3;
            this.listpeoplelistbox.SelectedIndexChanged += new System.EventHandler(this.Listpeoplelistbox_SelectedIndexChanged);
            // 
            // drop
            // 
            this.drop.BackColor = System.Drawing.Color.ForestGreen;
            this.drop.Font = new System.Drawing.Font("Haettenschweiler", 9.75F);
            this.drop.ForeColor = System.Drawing.Color.White;
            this.drop.Location = new System.Drawing.Point(109, 165);
            this.drop.Name = "drop";
            this.drop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.drop.Size = new System.Drawing.Size(75, 23);
            this.drop.TabIndex = 4;
            this.drop.Text = "حذف";
            this.drop.UseVisualStyleBackColor = false;
            this.drop.Click += new System.EventHandler(this.Drop_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(331, 150);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.Font = new System.Drawing.Font("Haettenschweiler", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(191, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "ویرایش";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 379);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.drop);
            this.Controls.Add(this.listpeoplelistbox);
            this.Controls.Add(this.addpeople);
            this.Controls.Add(this.lname);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.add);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "لیست افراد";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.Button addpeople;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listpeoplelistbox;
        private System.Windows.Forms.Button drop;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;

        #endregion

        //private DataSetTelephone dataSetTelephone1;
        //private DataSetTelephoneTableAdapters.PhoneTableTableAdapter phoneTableTableAdapter1;
        //private DataSetTelephoneTableAdapters.TableAdapterManager tableAdapterManager1;
        //private TelephoneDataSet telephoneDataSet1;
        //private System.Windows.Forms.DataGridView dataGridView1;
    }
}