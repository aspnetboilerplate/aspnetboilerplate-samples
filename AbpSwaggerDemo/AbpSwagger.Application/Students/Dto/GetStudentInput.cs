using Abp.Runtime.Validation;

namespace AbpSwagger.Application.Students.Dto
{
    public class GetStudentInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "FirstName";
            }
        }
    }
}
