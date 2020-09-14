using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevExtremeMvcApp2.Models
{
    public class TreeViewOptions {
        public TreeViewOptions()
        {
            AllowCheckNodes = true;
            AllowSelectNode = true;
            EnableAnimation = true;
            EnableHotTrack = true;
            ShowTreeLines = true;
            ShowExpandButtons = true;
        }

        public bool AllowCheckNodes { get; set; }
        public bool AllowSelectNode { get; set; }
        public bool CheckNodesRecursive { get; set; }
        public bool EnableAnimation { get; set; }
        public bool EnableHotTrack { get; set; }
        public bool ShowTreeLines { get; set; }
        public bool ShowExpandButtons { get; set; }
    }
}