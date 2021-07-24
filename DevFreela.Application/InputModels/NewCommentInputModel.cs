using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class NewCommentInputModel
    {
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
    }
}
