using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLPLib;
using NLPLib.XMLBind.Configuration;

namespace NLP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Global Variables
        string selectedBlock = string.Empty;
        string naturalLanguageCondition = string.Empty;
        string naturalLanguageCode = string.Empty;
        string selectedAction = string.Empty;
        string clickedConditionBlock = string.Empty;
        string clickedActionBlock = string.Empty;
        List<string> mathList = new List<string>();
        List<string> logicList = new List<string>();
        List<string> alertList = new List<string>();
        List<string> drawList = new List<string>();
        List<string> optionList = new List<string>();
        List<string> actionList = new List<string>();
        List<string> generalList = new List<string>();

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            /*At first hide all panels*/
            pnlCreateBlock.Visible = false;
            pnlAddVariables.Visible = false;
            pnlIfThenBlock.Visible = false;
            pnlIfElseBlock.Visible = false;
            pnlAddCondition.Visible = false;
            pnlAddAction.Visible = false;

            /*Control Value*/
            lblAddConditionLeftNumber.Text = string.Empty;
            lblAddConditionComparison.Text = string.Empty;
            lblAddConditionRightNumber.Text = string.Empty;

            /*Load DropDowns*/
            LoadLeftNumberCondition();
            LoadRightNumberCondition();
            LoadComparisonCondition();

            /*Load TreeView Options*/
            LoadTreeViewOptions();
        }

        private void LoadTreeViewOptions()
        { 
            //load here
            //demo data
            /*TreeNode numberNode = new TreeNode("number");
            numberNode.Nodes.Add("constant");
            numberNode.Nodes.Add("decimal constant");

            TreeNode comparisonNode = new TreeNode("comparison");
            comparisonNode.Nodes.Add("is lower than");

            treeViewOptions.Nodes.Add(numberNode);
            treeViewOptions.Nodes.Add(comparisonNode);*/
            

            WorkspaceController wc = new WorkspaceController();
            wc.loadWorkspaceSetting();

            treeViewOptions.AllowDrop = true;
            pnlLeft.AllowDrop = true;

            List<BlockDrawer> blockDrawers = BlockLoadingUtils.blockLangDef.blockDrawerSets[0].blockDrawer;

            for (int i = 0; i < blockDrawers.Count; i++)
            {
                TreeNode drawerNode = new TreeNode(blockDrawers[i].name);

                for (int j = 0; j < blockDrawers[i].blockGenusMember.Count; j++)
                {
                    string genusName = blockDrawers[i].blockGenusMember[j];
                    
                    BlockGenus blockGenus = BlockLoadingUtils.getGenusWithName(genusName);

                    drawerNode.Nodes.Add(blockGenus.initlabel);
                    
                    switch (blockDrawers[i].name)
                    {
                        case "Math":
                            mathList.Add(blockGenus.initlabel);
                            break;
                        case "Logic":
                            logicList.Add(blockGenus.initlabel);
                            break;
                        case "Alerts":
                            alertList.Add(blockGenus.initlabel);
                            break;
                        case "Draw":
                            drawList.Add(blockGenus.initlabel);
                            break;
                        case "Option":
                            optionList.Add(blockGenus.initlabel);
                            break;
                        case "Action":
                            actionList.Add(blockGenus.initlabel);
                            break;
                        default:
                            generalList.Add(blockGenus.initlabel);
                            break;
                    }
                }

                treeViewOptions.Nodes.Add(drawerNode);
            }

        }

        private void LoadLeftNumberCondition()
        {
            cmdAddConditionLeftNumber.Items.Add("0");
            cmdAddConditionLeftNumber.Items.Add("0.0");
        }

        private void LoadRightNumberCondition()
        {
            cmdAddConditionRightNumber.Items.Add("0");
            cmdAddConditionRightNumber.Items.Add("0.0");
        }

        private void LoadComparisonCondition()
        {
            cmdAddCondiotionComparison.Items.Add("is higher than");
            cmdAddCondiotionComparison.Items.Add("is lower than");
            cmdAddCondiotionComparison.Items.Add("is higher than or equal to");
            cmdAddCondiotionComparison.Items.Add("is lower than or equal to");
            cmdAddCondiotionComparison.Items.Add("is eqal to");
        }

        private void ControlsEnableFalse()
        {
            menuStrip1.Enabled = false;
            pnlLeft.Enabled = false;
            pnlRight.Enabled = false;
        }

        private void ControlsEnableTrue()
        {
            menuStrip1.Enabled = true;
            pnlLeft.Enabled = true;
            pnlRight.Enabled = true;
        }

        private void txtEditBlock_Click(object sender, EventArgs e)
        {
            pnlCreateBlock.Visible = true;
            txtCreateIFTHENblock.BackColor = Color.White;
            txtCreateIFTHENELSEblock.BackColor = Color.White;
            pnlCreateBlock.Location = new Point(300, 220);
            ControlsEnableFalse();
        }
        
        private void txtCreateIFTHENblock_Click(object sender, EventArgs e)
        {
            txtCreateIFTHENblock.BackColor = Color.Green;
            selectedBlock = "If_Then";
            txtCreateIFTHENELSEblock.BackColor = Color.White;
        }

        private void txtCreateIFTHENELSEblock_Click(object sender, EventArgs e)
        {
            txtCreateIFTHENELSEblock.BackColor = Color.Green;
            selectedBlock = "If_Then_Else";
            txtCreateIFTHENblock.BackColor = Color.White;
        }

        private void btnCreateBlockOK_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(selectedBlock);
            if (selectedBlock == "If_Then_Else")
            {
                pnlIfThenBlock.Hide();
                pnlIfElseBlock.Show();
                pnlIfElseBlock.Location = new Point(0, 0);
            }
            else
            {
                pnlIfElseBlock.Hide();
                pnlIfThenBlock.Show();
                pnlIfThenBlock.Location = new Point(0, 0);
            }

            pnlCreateBlock.Hide();
            txtEditBlock.Hide();
            ControlsEnableTrue();
        }

        private void btnCreateBlockCancel_Click(object sender, EventArgs e)
        {
            pnlCreateBlock.Hide();
            ControlsEnableTrue();
        }

        private void addVariable_Click(object sender, EventArgs e)
        {
            pnlAddVariables.Visible = true;
            pnlAddVariables.Location = new Point(300, 220);
            ControlsEnableFalse();
        }

        private void btnSaveAddVariables_Click(object sender, EventArgs e)
        {
            if (txtAddVariableName.Text != "" && cmdAddVariableType.SelectedIndex != -1)
            {
                MessageBox.Show("Need to save local/file.");
                pnlAddVariables.Hide();
                ControlsEnableTrue();
            }
            else
            {
                MessageBox.Show("Enter necessary field's value.");
            }
        }

        private void btnCalcelAddVariables_Click(object sender, EventArgs e)
        {
            pnlAddVariables.Hide();
            ControlsEnableTrue();
        }

        private void cmdAddVariableType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdAddVariableType.SelectedIndex != -1)
            {
                if (cmdAddVariableType.SelectedItem.ToString() == "Boolean")
                {
                    lblAddVariableValue.Hide();
                    txtAddVariableValue.Hide();
                    cmdAddVariableBooleanValue.Show();
                }
                
                if (cmdAddVariableType.SelectedItem.ToString() == "Number")
                {
                    cmdAddVariableBooleanValue.Hide();
                    lblAddVariableValue.Show();
                    txtAddVariableValue.Show();
                }
            }
        }

        private void txtIFCondition_Click(object sender, EventArgs e)
        {
            clickedConditionBlock = "If";
            pnlAddCondition.Show();
            pnlAddCondition.Location = new Point(200, 220);
            ControlsEnableFalse();
        }

        private void txtIfThenAction_Click(object sender, EventArgs e)
        {
            clickedActionBlock = "IfThen";
            MakeActionTextBgWhite();
            pnlAddAction.Show();
            pnlAddAction.Location = new Point(300, 220);
            ControlsEnableFalse();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlIfElseBlock.Hide();
            pnlIfThenBlock.Hide();
            txtEditBlock.Show();
        }

        private void cmdAddConditionLeftNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdAddConditionLeftNumber.SelectedIndex != -1)
            {
                lblAddConditionLeftNumber.Text = cmdAddConditionLeftNumber.SelectedItem.ToString();
            }
        }

        private void cmdAddCondiotionComparison_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdAddCondiotionComparison.SelectedIndex != -1)
            {
                lblAddConditionComparison.Text = cmdAddCondiotionComparison.SelectedItem.ToString();
            }
        }

        private void cmdAddConditionRightNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdAddConditionRightNumber.SelectedIndex != -1)
            {
                lblAddConditionRightNumber.Text = cmdAddConditionRightNumber.SelectedItem.ToString();
            }
        }

        private void btnAddConditionOk_Click(object sender, EventArgs e)
        {
            naturalLanguageCondition = lblAddConditionLeftNumber.Text + " " + lblAddConditionComparison.Text + " " + lblAddConditionRightNumber.Text;
            txtCondition.Text = naturalLanguageCondition;

            if (clickedConditionBlock == "If")
            {
                txtIFCondition.Text = naturalLanguageCondition;
            }
            else
            {
                txtIfElseIfCondition.Text = naturalLanguageCondition;
            }

            pnlAddCondition.Hide();
            ControlsEnableTrue();
        }

        private void btnAddConditionCancel_Click(object sender, EventArgs e)
        {
            pnlAddCondition.Hide();
            ControlsEnableTrue();
        }

        private void txtFirstAction_Click(object sender, EventArgs e)
        {
            txtFirstAction.BackColor = Color.Green;
            selectedAction = "run_on_monday";
            txtSecondAction.BackColor = Color.White;
        }

        private void txtSecondAction_Click(object sender, EventArgs e)
        {
            txtSecondAction.BackColor = Color.Green;
            selectedAction = "sleep_on_monday_at20";
            txtFirstAction.BackColor = Color.White;
        }

        private void btnAddActionOk_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(selectedBlock);
            /*
            foreach (string item in actionList)
            {
                MessageBox.Show(item);
            }
              */
            if (selectedAction == "run_on_monday")
            {
                SetActionTextBlock("run on Monday");
                txtCondition.Text = "run on Monday";
                txtCode.Text = "Run(Monday)";
            }
            else
            {
                SetActionTextBlock("sleep on Monday at 20");
                txtCondition.Text = "sleep on Monday at 20";
                txtCode.Text = "Sleep(Monday)";
            }

            pnlAddAction.Hide();
            ControlsEnableTrue();
        }

        private void btnAddActionCancel_Click(object sender, EventArgs e)
        {
            pnlAddAction.Hide();
            ControlsEnableTrue();
        }

        private void txtIfElseIfCondition_Click(object sender, EventArgs e)
        {
            clickedConditionBlock = "IfElseIf";
            pnlAddCondition.Show();
            pnlAddCondition.Location = new Point(300, 220);
            ControlsEnableFalse();
        }

        private void txtIfElseThenAction_Click(object sender, EventArgs e)
        {
            clickedActionBlock = "IfElseThen";
            MakeActionTextBgWhite();
            pnlAddAction.Show();
            pnlAddAction.Location = new Point(300, 220);
            ControlsEnableFalse();
        }

        private void txtIfElseElseAction_Click(object sender, EventArgs e)
        {
            clickedActionBlock = "IfElseElse";
            MakeActionTextBgWhite();
            pnlAddAction.Show();
            pnlAddAction.Location = new Point(300, 220);
            ControlsEnableFalse();
        }

        private void MakeActionTextBgWhite()
        {
            txtFirstAction.BackColor = Color.White;
            txtSecondAction.BackColor = Color.White;
        }

        private void SetActionTextBlock(string actionText)
        {
            if (clickedActionBlock == "IfThen")
            {
                txtIfThenAction.Text = actionText;
            }
            else if (clickedActionBlock == "IfElseThen")
            {
                txtIfElseThenAction.Text = actionText;
            }
            else
            {
                txtIfElseElseAction.Text = actionText;
            }
            
        }

        private void addBlock_Click(object sender, EventArgs e)
        {

        }

        private void treeViewOptions_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move); 
        }

        private void treeViewOptions_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void pnlLeft_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void pnlLeft_DragDrop(object sender, DragEventArgs e)
        {
            /*
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                
                TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                Console.WriteLine(node.Text);
                if (node.Text == "if")
                {
                    this.pnlIfThenBlock.Show();
                    pnlLeft.Controls.Add(pnlIfThenBlock);
                }
                if (node.Text == "ifelse")
                {
                    this.pnlIfElseBlock.Show();
                    pnlLeft.Controls.Add(pnlIfElseBlock);
                }
              
            }
            */
            
        }
        
    }
}
