using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisitorManagementForm.Models
{
    public class VisitorRequestModel
    {
            public int RequestorId { get; set; }
            public int BusinessUnitId { get; set; }
            public string BusinessUnitName { get; set; }
            public int LocationId { get; set; }
            public string LocationName { get; set; }
            public string RequestorName { get; set; }
            public string RequestorEmail { get; set; }
            public string RequerstorMobile { get; set; }
            public string RequestorDesignation { get; set; }
            public string RequestorDepartment { get; set; }
            public string VisitorName { get; set; }
            public string VisitorEmail { get; set; }
            public string VisitorMobile { get; set; }
            public string VisitorDesignation { get; set; }
            public string VisitorCompany { get; set; }
            public string VisitorNationality { get; set; }
            public string PurposeOfVisitSQ { get; set; }
            public string Chainavisit { get; set; }
            public string CraeteDate { get; set; }
            public DateTime VisitDate { get; set; }
            public string UpdateDate { get; set; }
            public int IsApproved { get; set; }
    }
}