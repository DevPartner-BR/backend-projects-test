using AutoFixture.Kernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Testes
{
    public class MaxLengthAttributeRelay : ISpecimenBuilder
    {
        /// <summary>
        /// Creates a new specimen based on a specified maximum length of characters that are allowed.
        /// </summary>
        /// <param name="request">The request that describes what to create.</param>
        /// <param name="context">A container that can be used to create other specimens.</param>
        /// <returns>
        /// A specimen created from a <see cref="MaxLengthAttribute"/> encapsulating the operand
        /// type and the maximum of the requested number, if possible; otherwise,
        /// a <see cref="NoSpecimen"/> instance.
        ///  Source: https://github.com/AutoFixture/AutoFixture/blob/ab829640ed8e02776e4f4730d0e72ab3cc382339/Src/AutoFixture/DataAnnotations/StringLengthAttributeRelay.cs
        /// This code is heavily based on the above code from the source library that was originally intended
        /// to recognized the StringLengthAttribute and has been modified to examine the MaxLengthAttribute instead.
        /// </returns>
        public object Create(object request, ISpecimenContext context)
        {
            if (request == null)
                return new NoSpecimen();

            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var customAttributeProvider = request as ICustomAttributeProvider;
            if (customAttributeProvider == null)
                return new NoSpecimen();

            var maxLengthAttribute = customAttributeProvider.GetCustomAttributes(typeof(MaxLengthAttribute), inherit: true).Cast<MaxLengthAttribute>().SingleOrDefault();
            if (maxLengthAttribute == null)
                return new NoSpecimen();

            return context.Resolve(new ConstrainedStringRequest(maxLengthAttribute.Length));
        }
    }
}