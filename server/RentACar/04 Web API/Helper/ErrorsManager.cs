using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace MySpace
{
    public class ErrorsManager
    {
        public static string GetInnerMessage(Exception ex)
        {
#if DEBUG
            // Check if there isn't inner exception. If there isn't - return message: 
            if (ex.InnerException == null)
                return ex.Message;

            // Return the message of the inner exception:
            return GetInnerMessage(ex.InnerException);
#else
            return "Some error occurred, please try again.";
#endif
        }

        public static List<string> GetErrors(ModelStateDictionary modelState)
        {
            // אוסף של כל הודעות השגיאות שיכולות להיות
            List<string> errors = new List<string>();

            #region Inner Loop

            // ריצה על כל המאפיינים של המודל שנכשלו
            foreach (var property in modelState.Values)
            {
                // ריצה על כל השגיאות של כל מאפיין
                foreach (var err in property.Errors)
                {
                    // List-הוספת הודעת השגיאה ל
                    errors.Add(err.ErrorMessage);
                }
            }

            #endregion

            // החזרת אוסף השגיאות
            return errors;
        }
    }
}