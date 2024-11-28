using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackleberrySharedModels.Requests
{
    public class GetQuestionsByExerciseId
    {
        public Guid ExerciseId { get; set; }
    }
}
