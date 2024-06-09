using TutorMe.Core.Enums;

namespace TutorMe.Core.Entities;

public class User : BaseEntity
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Registration { get; private set; }
    public string Course { get; private set; }
    public string Username { get; private set; }
    public RoleEnum Role { get; private set; }
    public string Password { get; private set; }
    public bool IsTutor { get; private set; }
    public List<Post>? Posts { get; private set; }
    public List<PostComment>? PostComments { get; private set; }
    public List<PostLike>? PostLikes { get; private set; }
    public List<Subscription>? Subscriptions { get; private set; }
    public List<SubjectGroup>? CreatedSubjectGroups { get; private set; }
    public List<CommentLike>? CommentLikes { get; private set; }

    public User(string fullName, string email, DateTime birthDate, string registration, string course, string username, RoleEnum role, string password, bool isTutor)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Registration = registration;
        Course = course;
        Username = username;
        Role = role;
        Password = password;
        IsTutor = isTutor;
    }
}