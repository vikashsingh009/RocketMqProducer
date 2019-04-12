using java.util;
using org.apache.rocketmq.client.producer;
using org.apache.rocketmq.common.message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerTestApp
{
    public class QueueSelector : MessageQueueSelector
    {
        public MessageQueue select(List mqs, Message m, object obj)
        {
            if (obj != null)
            {
                MD5 md5Hasher = MD5.Create();
                var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes((String)obj));
                var ivalue = BitConverter.ToInt32(hashed, 0);
                int index = Math.Abs(ivalue % (int)mqs.size());
                return (MessageQueue)mqs.get(index);
            }
            else
            {
                return (MessageQueue)mqs.get(0);
            }
        }
    }
}
