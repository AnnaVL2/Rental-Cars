using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpace
{
    public class BranchesLogic : BaseLogic
    {
        public List<BranchDTO> GetAllBranches()
        {
            var q = from b in DB.Branches
                    select new BranchDTO
                    {
                        branchID = b.BranchID,
                        branchAddress = b.BranchAddress,
                        branchLocation = b.BranchLocation,
                        branchName = b.BranchName,
                    };

            return q.ToList();
        }

        //public BranchDTO GetOneBranch(int branchID)
        //{
        //    var q = from branch in DB.Branches
        //            where branch.BranchID == branchID
        //            select new BranchDTO
        //            {
        //                branchID = branch.BranchID,
        //                branchAddress = branch.BranchAddress,
        //                branchLocation = branch.BranchLocation,
        //                branchName = branch.BranchName,
        //            };
        //    return q.SingleOrDefault();
        //}

        //public BranchDTO AddBranch(BranchDTO branch)
        //{
        //    Branch branchToAdd = new Branch{
        //        BranchID = branch.branchID,
        //        BranchAddress = branch.branchAddress,
        //        BranchLocation = branch.branchLocation,
        //        BranchName = branch.branchName
        //    };

        //    DB.Branches.Add(branchToAdd);
        //    DB.SaveChanges();
        //    branch.branchID = branchToAdd.BranchID;
        //    return branch;
        //}

        //public void DeleteBranch(int id)
        //{
        //    Branch branchToDelete = DB.Branches
        //         .Where(b => b.BranchID == id).SingleOrDefault();
        //    if (branchToDelete != null)
        //    {
        //        DB.Branches.Remove(branchToDelete);
        //        DB.SaveChanges();
        //    }
        //}
    }
}
