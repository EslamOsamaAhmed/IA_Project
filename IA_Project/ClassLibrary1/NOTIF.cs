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
    
    public partial class NOTIF
    {
        public int ACTOR_ID_FROM { get; set; }
        public int ACTOR_ID_TO { get; set; }
        public string CONTENT { get; set; }
        public string TYPE { get; set; }
    
        public virtual S_ACTORS S_ACTORS { get; set; }
        public virtual S_ACTORS S_ACTORS1 { get; set; }
    }
}
