﻿using Balta.NotificationContext;
using Balta.SharedContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balta.SubscriptionContext
{
    public class Student : Base
    {
        public Student()
        {
            Subscriptions = new List<Subscription>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Subscription> Subscriptions { get; set; }
        public User User { get; set; }
        public bool IsPremium => Subscriptions.Any(x => !x.IsInactive);

        public void CreateSubscription(Subscription subscription)
        {
            if (IsPremium)
            {
                AddNotification(new Notification("Premium", "O aluno já tem assinatura ativa!"));
                return;
            }      

            Subscriptions.Add(subscription);
        }
    }
}
