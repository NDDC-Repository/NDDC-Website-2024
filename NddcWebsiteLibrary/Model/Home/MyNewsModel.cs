﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Model.Home
{
    public class MyNewsModel
    {
        public int Id { get; set; }
        public int NID { get; set; }
        public string Subject { get; set; }
        public string Summary { get; set; }

        private string mShortSubject;

        public string ShortSubject
        {
            get {
                if (Subject.Length > 50)
                {
					mShortSubject = Subject.Substring(0, 50);
					return mShortSubject;
				}
                mShortSubject = Subject;

				return mShortSubject;
			}
               
        }
        private string mShortSummary;

        public string ShortSummary
        {
            get
            {
                if (Summary.Length > 100)
                {
					mShortSummary = Summary.Substring(0, 100);
					return mShortSummary;
				}
                mShortSummary = Summary;
                return mShortSummary;
            }
        }

        public string NewsId { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; } = DateTime.Now;
        public Boolean TimeStamp { get; set; }
        public Boolean Enabled { get; set; }
        public string Type { get; set; }
        public Boolean SetAsSlide { get; set; }
        public string Tags { get; set; }
        public Boolean Archive { get; set; }
        public int Views { get; set; }
        public int Clicks { get; set; }
        public int NDID { get; set; }
        public int CMID { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}
