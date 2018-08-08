﻿using System;
using System.Collections.Generic;

namespace PSModuleDevelopment.Template
{
    /// <summary>
    /// The master class containing a template
    /// </summary>
    [Serializable]
    public class Template
    {
        /// <summary>
        /// The name of the template
        /// </summary>
        public string Name;

        /// <summary>
        /// What kind of template is this?
        /// </summary>
        public TemplateType Type;

        /// <summary>
        /// What version is the template
        /// </summary>
        public Version Version;

        /// <summary>
        /// Text describing the template
        /// </summary>
        public string Description;

        /// <summary>
        /// Author of the template
        /// </summary>
        public string Author;

        /// <summary>
        /// When was the template originally created?
        /// </summary>
        public DateTime CreatedOn;

        /// <summary>
        /// List of tags that have been assigned to the template
        /// </summary>
        public List<string> Tags = new List<string>();

        /// <summary>
        /// List of parameters the template accepts
        /// </summary>
        public List<string> Parameters = new List<string>();

        /// <summary>
        /// List of descriptions for parameters. Will be displayed if the corresponding parameter is being prompted for
        /// </summary>
        public Dictionary<string, string> ParameterDescriptions = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// List of scripts that will be invoked on initialization
        /// </summary>
        public Dictionary<string, ParameterScript> Scripts = new Dictionary<string, ParameterScript>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Items in the root directory of the template (which may contain children themselves).
        /// </summary>
        public List<TemplateItemBase> Children = new List<TemplateItemBase>();

        /// <summary>
        /// Version of the template schema used to create the template.
        /// Used to track legacy templates and prevent breaking their invocation.
        /// </summary>
        public Version SchemaVersion = new Version(2, 0);

        /// <summary>
        /// Returns the template digest used as index file.
        /// </summary>
        /// <returns>A TemplateInfo object describing this template.</returns>
        public TemplateInfo ToTemplateInfo()
        {
            TemplateInfo info = new TemplateInfo();
            info.Author = Author;
            info.CreatedOn = CreatedOn;
            info.Description = Description;
            info.Name = Name;
            info.Parameters = Parameters;
            info.Tags = Tags;
            info.Type = Type;
            info.Version = Version;
            info.SchemaVersion = SchemaVersion;

            return info;
        }
    }
}
