//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace office360.Models.EDMX
{
    using System;
    
    public partial class AASM_AdmissionSession_GetListBySearch_Result
    {
        public int Id { get; set; }
        public Nullable<System.Guid> GuID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> SessionStartDate { get; set; }
        public Nullable<System.DateTime> SessionEndDate { get; set; }
        public Nullable<System.DateTime> AdmissionStartDate { get; set; }
        public Nullable<System.DateTime> AdmissionEndDate { get; set; }
        public string AcademicYear { get; set; }
        public string Classes { get; set; }
        public Nullable<bool> IsEnteryTestRequired { get; set; }
        public Nullable<bool> IsInterviewRequired { get; set; }
        public Nullable<int> DocumentStatus { get; set; }
        public string Campus { get; set; }
    }
}
