namespace AbpWcfDemo.Services {

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "First" in both code and config file together.
    public class SimpleService : ISimpleService {

        public string Echo(string echo) {
            return "Simple: " + echo;
        }

        public string EchoWithPost(string echo) {
            return "Simple post: " + echo;
        }
    }
}
