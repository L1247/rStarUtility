#region

using System;

#endregion

namespace Utilities.Contract
{
    public static class Contract
    {
    #region Public Variables

        public static bool CHECK_CLASS_INVARIANT = true;
        public static bool CHECK_POST            = true;
        public static bool CHECK_PRE             = true;

    #endregion

    #region Public Methods

        public static void ClassInvariant(bool value , string annotation = "")
        {
            if (CHECK_CLASS_INVARIANT == false) return;
            if (value == false) ThrowClassInvariantViolationException(annotation);
        }

        public static void ClassInvariantNotNull(object obj , string annotation = "")
        {
            if (CHECK_CLASS_INVARIANT == false) return;
            var objNotNull = obj != null;
            if (objNotNull == false) ThrowClassInvariantViolationException($"{annotation} can not be null");
        }

        public static void ClassInvariantString(string str , string annotation = "")
        {
            if (CHECK_CLASS_INVARIANT == false) return;
            if (string.IsNullOrEmpty(str))
                ThrowClassInvariantViolationException(
                    $"{annotation} can not be empty or null");
        }

        public static void Ensure(bool value , string annotation = "")
        {
            if (CHECK_POST == false) return;
            if (value == false) ThrowPostConditionViolation(annotation);
        }

        public static void EnsureNotNull(object obj , string annotation = "")
        {
            if (CHECK_POST == false) return;
            var notNull = obj != null;
            if (notNull == false) ThrowPostConditionViolation($"{annotation} can not be null");
        }

        public static void EnsureString(string str , string annotation = "")
        {
            if (CHECK_POST == false) return;
            if (string.IsNullOrEmpty(str))
                ThrowPostConditionViolation($"{annotation} can not be empty or null");
        }

        public static void Require(bool value , string annotation = "")
        {
            if (CHECK_PRE == false) return;
            if (value == false) ThrowPreconditionViolationException(annotation);
        }

        public static void RequireNotNull(object obj , string annotation = "")
        {
            if (CHECK_PRE == false) return;
            var notNull = obj == null;
            if (notNull)
            {
                var notNullAnnotation = $"{annotation} can not be null";
                ThrowPreconditionViolationException(notNullAnnotation);
            }
        }

        public static void RequireString(string str , string annotation = "")
        {
            if (CHECK_PRE == false) return;
            if (string.IsNullOrEmpty(str))
            {
                var notNullAnnotation = $"{annotation} can not be empty or null";
                ThrowPreconditionViolationException(notNullAnnotation);
            }
        }

    #endregion

    #region Private Methods

        private static void ThrowClassInvariantViolationException(string annotation)
        {
            throw new ClassInvariantViolationException(annotation);
        }

        private static void ThrowPostConditionViolation(string annotation)
        {
            throw new PostConditionViolationException(annotation);
        }

        private static void ThrowPreconditionViolationException(string notNullAnnotation)
        {
            throw new PreconditionViolationException(notNullAnnotation);
        }

    #endregion
    }

    public class PreconditionViolationException : Exception
    {
    #region Constructor

        public PreconditionViolationException(string annotation) : base(annotation) { }

    #endregion
    }

    public class PostConditionViolationException : Exception
    {
    #region Constructor

        public PostConditionViolationException(string annotation) : base(annotation) { }

    #endregion
    }

    public class ClassInvariantViolationException : Exception
    {
    #region Constructor

        public ClassInvariantViolationException(string annotation) : base(annotation) { }

    #endregion
    }
}