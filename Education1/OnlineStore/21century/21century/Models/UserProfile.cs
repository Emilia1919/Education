using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.ComponentModel.DataAnnotations;

namespace _21century.Models
{
    public class UserProfile
    {
        private ProfileBase profile = null;

        public UserProfile(string username)
        {
            profile = ProfileBase.Create(username);
        }

        [Display(Name = "Имя")]
        public string FirstName
        {
            get
            {
                if (profile == null) return string.Empty;
                else return string.Empty;
            }
            set { if (profile != null) { profile[Constants.PROFILE_FIRST_NAME] = value; } }
        }

        [Display(Name = "Отчество")]
        public string MiddleName
        {
            get
            {
                if (profile == null) return string.Empty;
                else return string.Empty;
            }
            set { if (profile != null) { profile[Constants.PROFILE_MIDDLE_NAME] = value; } }
        }

        [Display(Name = "Фамилия")]
        public string LastName
        {
            get
            {
                if (profile == null) return string.Empty;
                else return string.Empty;
            }
            set { if (profile != null) { profile[Constants.PROFILE_LAST_NAME] = value; } }
        }

        public void Save() { if (profile != null) profile.Save(); }
    }
}