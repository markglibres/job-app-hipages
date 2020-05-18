using System;
using Ardalis.GuardClauses;
using BizzPo.Core.Domain;

namespace Leads.Domain.Extensions
{
    public static class GuardClauseExtensions
    {
        public static void Empty( this IGuardClause guardClause, string input, string parameterName )
        {
            guardClause.Empty<DomainException>( input, parameterName );
        }

        public static void Empty( this IGuardClause guardClause, Guid input, string parameterName )
        {
            guardClause.Empty<DomainException>( input, parameterName );
        }

        public static void ZeroOrNegative( this IGuardClause guardClause, int input, string parameterName )
        {
            guardClause.ZeroOrNegative<DomainException>( input, parameterName );
        }

        public static void NullObject( this IGuardClause guardClause, object input, string parameterName )
        {
            guardClause.NullObject<DomainException>( input, parameterName );
        }

        public static void ZeroOrNegative( this IGuardClause guardClause, decimal input, string parameterName )
        {
            guardClause.ZeroOrNegative<DomainException>( input, parameterName );
        }

        public static void Empty<T>( this IGuardClause guardClause, string input, string parameterName )
            where T : Exception
        {
            if ( !string.IsNullOrWhiteSpace( input ) )
            {
                return;
            }

            var message = $"{parameterName} cannot be null or empty";
            ThrowError<T>( message );
        }

        public static void Empty<T>( this IGuardClause guardClause, Guid input, string parameterName )
            where T : Exception
        {
            if ( !Guid.Empty.Equals( input ) )
            {
                return;
            }

            var message = $"{parameterName} cannot be an empty GUID";
            ThrowError<T>( message );
        }

        public static void ZeroOrNegative<T>( this IGuardClause guardClause, int input, string parameterName )
            where T : Exception
        {
            if ( input > 0 )
            {
                return;
            }

            var message = $"{parameterName} should be greater than 0";
            ThrowError<T>( message );
        }

        public static void NullObject<T>( this IGuardClause guardClause, object input, string parameterName )
            where T : Exception
        {
            if ( input != null )
            {
                return;
            }

            var message = $"{parameterName} should not be null";
            ThrowError<T>( message );
        }

        public static void ZeroOrNegative<T>( this IGuardClause guardClause, decimal input, string parameterName )
            where T : Exception
        {
            if ( input > 0 )
            {
                return;
            }

            var message = $"{parameterName} should be greater than 0";
            ThrowError<T>( message );
        }

        private static void ThrowError<T>( string message )
            where T : Exception
        {
            throw ( T ) Activator.CreateInstance( typeof( T ), message );
        }
    }
}