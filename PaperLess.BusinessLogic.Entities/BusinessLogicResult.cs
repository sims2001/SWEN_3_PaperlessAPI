using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperLess.BusinessLogic.Entities {
    public class BusinessLogicResult<T> {
        public bool IsSuccess { get; set; }
        public T? Result { get; set; }
        public List<string> Errors { get; set; }

        public BusinessLogicResult() {
            Errors = new List<string>();
        }
    }

    public class BusinessLogicResult {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        public BusinessLogicResult() {
            Errors = new List<string>();
        }
    }
}
