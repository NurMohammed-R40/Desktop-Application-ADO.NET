﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR_Management
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HR_DBEntities2 : DbContext
    {
        public HR_DBEntities2()
            : base("name=HR_DBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<spDepartmentWiseEmployeeList_Result> spDepartmentWiseEmployeeList(Nullable<int> departmentId)
        {
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("departmentId", departmentId) :
                new ObjectParameter("departmentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spDepartmentWiseEmployeeList_Result>("spDepartmentWiseEmployeeList", departmentIdParameter);
        }

    }
}