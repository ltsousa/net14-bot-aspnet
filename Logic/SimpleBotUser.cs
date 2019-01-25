using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            var cliente = new MongoClient("mongodb://localhost");

            var db = cliente.GetDatabase("cliente");
            var col = db.GetCollection<BsonDocument>("cliente");

            
            var ret = message.Id;
            var dado = message.Text;
            var txt = message.User;

            var doc = new BsonDocument() {
                                            { "campo1", ret },
                                            { "campo2", dado },
                                            { "campo3", txt }
                                           };

            col.InsertOne(doc);
            return $"{message.User} disse '{message.Text}";
        }

    }
}