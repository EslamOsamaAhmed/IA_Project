//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class STAT_REPROT
    {
        public int ACTOR_ID_R { get; set; }
        public int NO_PROJECTS { get; set; }
        public int NO_COMPLETE { get; set; }
        public int NO_DELV { get; set; }
        public int NO_CURRENT { get; set; }
        public int NO_PASSED { get; set; }
        public int NO_FAILURE { get; set; }
    
        public virtual S_ACTORS S_ACTORS { get; set; }
    }
}