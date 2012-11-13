using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using NLPLib.XMLBind.Project;
using NLPLib.XMLBind.Configuration;
using System.Reflection;
using System.IO;

namespace NLPLib
{
    public class WorkspaceController
    {
        private bool langDefDirty = false;
        private string langDefContent;
        private string langDefResourcePath = "NLPLib.resources.lang_def.xml";

        public void loadProject(string projectContent)
        {
            if(langDefDirty)
            {
                setLangDefFromResource();
            }
            loadProject(projectContent, langDefContent);
        }

        public void loadProject(string projectContent, string langDefContent)
        {
            if (!String.IsNullOrEmpty(projectContent))
            {
                // load all project blocks
            }
            BlockLoadingUtils.loadLangDefBlocks(langDefContent);

        }

        public void loadWorkspaceSetting()
        {
            setLangDefFromResource();
            loadProject(null);
        }

        public void setLangDefFromResource()
        {
            langDefDirty = false;

            langDefContent = getContentFromResource(langDefResourcePath);
            if(String.IsNullOrEmpty(langDefContent))
            {
                throw new Exception("langDefContent null exception.");
            }
        }

        public void setLangDefString(string langDefContent)
        {
            this.langDefContent = langDefContent;
        }

        private string getContentFromResource(string resourcePath)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            string[] names = _assembly.GetManifestResourceNames();
            string resourceContent = null;
            using (var stream = new StreamReader(_assembly.GetManifestResourceStream(resourcePath)))
            {
                resourceContent = stream.ReadToEnd();
            }
            return resourceContent;
        }
    }
}
