using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.IOC
{

    public class Registration
    {
        public Type ForType { get; set; }
        public object ForObject { get; set; }
    }

    public class IocContainer
    {
        #region Logger
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        private List<Registration> registeredObjects = new List<Registration>();

        public object Resolve(Type type)
        {
            try
            {
                return registeredObjects
                    .Where(ele => ele.ForType == type)
                    .Select(ele => ele.ForObject)
                    .FirstOrDefault();


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return null;
        }

        public T Resolve<T>() where T : class
        {
            try
            {
                return Resolve(typeof(T)) as T;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return null;
        }

        public IEnumerable<object> ResolveAll(Type forType)
        {
            try
            {
                return registeredObjects
                      .Where(ele => ele.ForType == forType)
                      .Select(ele => ele.ForObject);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return new List<object>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            try
            {
                return ResolveAll(typeof(T)).Cast<T>();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return new List<T>();
        }

        public void Register(Registration regist)
        {
            registeredObjects.Add(regist);
        }



        private static IocContainer instance;
        public static IocContainer Instance
        {
            get
            {
                if (instance == null)
                    instance = new IocContainer();
                return instance;
            }
        }
    }
}
