using System;
using System.Net.Http;

namespace NetKegg.Compound {

    public class CompoundDb : KeggDb {
        public override string ConvertIds() {
            throw new NotImplementedException();
        }

        public override string ConvertIdsAsync() {
            throw new NotImplementedException();
        }

        public override string Find() {
            throw new NotImplementedException();
        }

        public override string FindAsync() {
            throw new NotImplementedException();
        }

        public override string Get() {
            throw new NotImplementedException();
        }

        public override string GetAsync() {
            string result = "";

            _web.DownloadStringCompleted += (sender, e) =>
                result = e.Result;
            _web.DownloadStringAsync(new Uri(HostName));

            return result;
        }

        public override string GetInfo() {
            throw new NotImplementedException();
        }

        public override string GetInfoAsync() {
            throw new NotImplementedException();
        }

        public override string LinkDbs() {
            throw new NotImplementedException();
        }

        public override string LinkDbsAsync() {
            throw new NotImplementedException();
        }

        public override string List() {
            throw new NotImplementedException();
        }

        public override string ListAsync() {
            throw new NotImplementedException();
        }
    }

}
