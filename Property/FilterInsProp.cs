using OpenCvSharp.Extensions;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JidamVision.Property
{
 
    public partial class FilterInsProp : UserControl
    {
        public event EventHandler<FilterSelectedEventArgs> FilterSelected;
        private String _selected_effect;
        private int _selected_effect2 = -1;
        private string op_values = "0 0 0";


        
        public FilterInsProp()
        {
            InitializeComponent();
        }

        private void select_effect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //���� �� �޺��ڽ��� ������ ������ ȿ���� �����ϸ� �� ȿ���� ���� �ؿ� �ߴ� �޺��ڽ������ �޶����.
            _selected_effect = Convert.ToString(select_effect.SelectedItem); //������ ȿ�� ����
            select_effect2.Items.Clear(); // ���� �׸���� ����� �� �׸��� �߰�
            if (_selected_effect == "����")
            {
                select_effect2.Items.Add("���ϱ�");
                select_effect2.Items.Add("����");
                select_effect2.Items.Add("���ϱ�");
                select_effect2.Items.Add("������");
                select_effect2.Items.Add("�ִ밪 ��");
                select_effect2.Items.Add("�ּҰ� ��");
                select_effect2.Items.Add("���밪 ���");
                select_effect2.Items.Add("���밪 ���� ���");
                select_effect2.Show();
                
            }
            else if (_selected_effect == "��Ʈ����(Bitwise)")
            {
                select_effect2.Items.Add("AND ����");
                select_effect2.Items.Add("OR ����");
                select_effect2.Items.Add("XOR ����");
                select_effect2.Items.Add("NOT ����");
                select_effect2.Show();
               
            }
            else if (_selected_effect == "����")
            {
                select_effect2.Items.Add("�� ����");
                select_effect2.Items.Add("�ڽ� ����");
                select_effect2.Items.Add("�̵�� ��");
                select_effect2.Items.Add("����þ� ��");
                select_effect2.Items.Add("����� ����");
                select_effect2.Show();
                
            }
            else if (_selected_effect == "Edge")
            {
                select_effect2.Items.Add("Sobel ����");
                select_effect2.Items.Add("Scharr ����");
                select_effect2.Items.Add("Laplacian ����");
                select_effect2.Items.Add("Canny ����");
                select_effect2.Show();
                
            }
            else
            {
                select_effect2.Hide();
                
            }
        }

        private void apply_Click(object sender, EventArgs e)
        {
            if (_selected_effect == null || _selected_effect2 == -1) // �� ��° ȿ���� ���õ��� ���� ���
            {
                MessageBox.Show("ȿ���� �������ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FilterSelected?.Invoke(this, new FilterSelectedEventArgs(_selected_effect,_selected_effect2));
        }

        private void select_effect2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selected_effect2 = Convert.ToInt32(select_effect2.SelectedIndex);// ���õ� �ε����� ����
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class FilterSelectedEventArgs : EventArgs
    {
        public string FilterSelected1 { get; }  //������ ����ȿ��
        public int FilterSelected2 { get; }  //���� �ɼǵ� �� �����Ѱ�

        public FilterSelectedEventArgs(string filterSelected, int filterSelected2) 
        {
            FilterSelected1 = filterSelected;
            FilterSelected2 = filterSelected2;

        }
    }
    /*partial class FilterInspProp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.select_effect2 = new System.Windows.Forms.ComboBox();
            this.select_effect = new System.Windows.Forms.ComboBox();
            this.apply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.select_effect2);
            this.groupBox1.Controls.Add(this.select_effect);
            this.groupBox1.Location = new System.Drawing.Point(29, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 158);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "�Ӽ�";
            // 
            // select_effect2
            // 
            this.select_effect2.FormattingEnabled = true;
            this.select_effect2.Location = new System.Drawing.Point(17, 94);
            this.select_effect2.Name = "select_effect2";
            this.select_effect2.Size = new System.Drawing.Size(248, 26);
            this.select_effect2.TabIndex = 1;
            this.select_effect2.SelectedIndexChanged += new System.EventHandler(this.select_effect2_SelectedIndexChanged);
            // 
            // select_effect
            // 
            this.select_effect.FormattingEnabled = true;
            this.select_effect.Items.AddRange(new object[] {
            "����",
            "��Ʈ����(Bitwise)",
            "����",
            "Edge"});
            this.select_effect.Location = new System.Drawing.Point(17, 43);
            this.select_effect.Name = "select_effect";
            this.select_effect.Size = new System.Drawing.Size(248, 26);
            this.select_effect.TabIndex = 0;
            this.select_effect.Text = "������ ȿ���� �����ϼ���.";
            this.select_effect.SelectedIndexChanged += new System.EventHandler(this.select_effect_SelectedIndexChanged);
            // 
            // apply
            // 
            this.apply.ForeColor = System.Drawing.SystemColors.Highlight;
            this.apply.Location = new System.Drawing.Point(29, 217);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(95, 37);
            this.apply.TabIndex = 7;
            this.apply.Text = "����";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // FilterInsProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.apply);
            this.Controls.Add(this.groupBox1);
            this.Name = "FilterInsProp";
            this.Size = new System.Drawing.Size(428, 415);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox select_effect2;
        private System.Windows.Forms.ComboBox select_effect;
        private System.Windows.Forms.Button apply;
    }*/


}
