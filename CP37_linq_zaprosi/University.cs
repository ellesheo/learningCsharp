using System;
using System.Collections.Generic;
using System.Text;

namespace CP37_linq_zaprosi
{
    public enum Course { Math, Physics, History }

    public record Student(int Id, string Name);

    public record Enrollment(int StudentId, Course Course, int Grade);

    public class InvalidEnrollmentException : Exception
    {
        public InvalidEnrollmentException() { }

        public InvalidEnrollmentException(string message) : base(message) { }

        public InvalidEnrollmentException(string message, Exception inner) : base(message, inner) { }
    }
}