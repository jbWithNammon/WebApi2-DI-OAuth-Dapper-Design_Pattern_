using ESN.Model.Constants;
using System.Collections.Generic;

namespace ESN.Model
{
    public class SearchResult<T>
    {
        public IEnumerable<T> ResultList { get; set; }
        public int TotalRecord { get; set; }
    }
    public class SearchParameter
    {
        public void ClearFilterList()
        {
            ConditionList = new List<SearchCondition>();
            SortAscending = true;
            Page = 0;
            ItemsPerPage = 10;
        }       
        public IEnumerable<SearchCondition> ConditionList { get; set; }     
        public string SortTable { get; set; }
        public string SortColumn { get; set; }        
        public bool SortAscending { get; set; }        
        public int? Page { get; set; }        
        public int? ItemsPerPage { get; set; }
    }
    public class SearchCondition
    {
        public SearchCondition()
        {
            this.LikePosition = LikePositionType.EndWords.GetAttrCode();
            GroupId = 0;
        }
        public string TableName { get; set; }        
        public string FieldName { get; set; }        
        public string ParameterName { get; set; }        
        public object Value { get; set; }
        public List<object> ListValues { get; set; }
        public string OperatorType { get; set; }
        public string JoinerType { get; set; }
        public string LikePosition { get; set; }  
        public int GroupId { get; set; }
    }
    public class AccountModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string LoggedOn { get; set; }
    }
    public class FileContent
    {
        public string FileName { get; set; }
        public byte[] Value { get; set; }
    }
}
