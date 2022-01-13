using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace OpenHackServerless.RatingsAPI.Model
{
    public class RatingModel {
        private string _userId;
        private string _productId;
        private string _location;
        private string _userNotes;
        private int _rating;
        private string _guid;
        private DateTime _timestamp;

        public RatingModel () {

        }

        public string userId {
            get {
                return _userId;
            }
            set {
                _userId= value;
            }
        }

        public string productId {
            get {
                return _productId;
            }
            set {
                _productId= value;
            }
        }

        public string location {
            get {
                return _location;
            }
            set {
                _location= value;
            }
        }

        public string userNotes {
            get {
                return _userNotes;
            }
            set {
                _userNotes= value;
            }
        }

        public string guid {
            get {
                return _guid;
            }
            set {
                _guid= value;
            }
        }

        public int rating {
            get {
                return _rating;
            }
            set {
                _rating= value;
            }
        }

        public DateTime timeStamp {
            get {
                return _timestamp;
            }
            set {
                _timestamp= value;
            }
        }
    }

}