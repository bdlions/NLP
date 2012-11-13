using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NLPLib;

namespace NLP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            WorkspaceController wc = new WorkspaceController();
            wc.setLangDefFromResource();
            wc.loadWorkspaceSetting();

            //Console.WriteLine("No of blockgenuse: "+BlockLoadingUtils.blockLangDef.blockGenuses.Count);
            Console.WriteLine("Block Id: "+BlockLoadingUtils.blockLangDef.blockGenuses[0].id);
            Console.WriteLine("Last block id: " + BlockLoadingUtils.nextBlockId);
            Console.WriteLine("First BlockDrawer "+BlockLoadingUtils.blockLangDef.blockDrawerSets[0].name);
            Console.WriteLine("no of Block drawers: " + BlockLoadingUtils.blockLangDef.blockDrawerSets[0].blockDrawer.Count);

            for (int i = 0; i < BlockLoadingUtils.blockLangDef.blockDrawerSets[0].blockDrawer.Count; i++)
            {
                Console.WriteLine(BlockLoadingUtils.blockLangDef.blockDrawerSets[0].blockDrawer[i].name);
            }
  
        }
    }
}
