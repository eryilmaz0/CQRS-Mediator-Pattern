using System;
using System.Collections;
using System.Collections.Generic;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Extensions
{
    public static class CollectionExtensions
    {

        public static bool ExecuteInTryCatch<TException>(this Func<object> function, ref Exception handledException) where TException : Exception
        {

            try
            {
                function();
                return true;
            }

            catch (Exception ex)
            {
                handledException = ex;  //KULLANICIYA HATAYI DÖNDÜR

                if (ex.GetType() == typeof(TException))
                    return false;

                //KULLANICININ BELİRTTİĞİ HATAYA TAKILMADI
                return true;

            }
        }
    }
}