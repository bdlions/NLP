using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLPLib;

namespace NLP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            WorkspaceController wc = new WorkspaceController();
            wc.setLangDefFromResource();
            wc.loadWorkspaceSetting();

            //Console.WriteLine("No of blockgenuse: "+BlockLoadingUtils.blockLangDef.blockGenuses.Count);
            richTextBox1.Text += "Block Id: " + BlockLoadingUtils.blockLangDef.blockGenuses[0].id + "\n";
            richTextBox1.Text += "Last block id: " + BlockLoadingUtils.nextBlockId + "\n";
            richTextBox1.Text += "First BlockDrawer " + BlockLoadingUtils.blockLangDef.blockDrawerSets[0].name + "\n";
            richTextBox1.Text += "no of Block drawers: " + BlockLoadingUtils.blockLangDef.blockDrawerSets[0].blockDrawer.Count + "\n";

            for (int i = 0; i < BlockLoadingUtils.blockLangDef.blockDrawerSets[0].blockDrawer.Count; i++)
            {
                richTextBox1.Text += BlockLoadingUtils.blockLangDef.blockDrawerSets[0].blockDrawer[i].name + "\n";
                for (int j = 0; j < BlockLoadingUtils.blockLangDef.blockDrawerSets[0].blockDrawer[i].blockGenusMember.Count; j++)
                {
                    string genusName = BlockLoadingUtils.blockLangDef.blockDrawerSets[0].blockDrawer[i].blockGenusMember[j];

                    richTextBox1.Text += "-" + BlockLoadingUtils.getGenusWithName(genusName).initlabel + "\n";
                }
            }

        }
    }
}
