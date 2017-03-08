using Cell.Data;

namespace Cell.Metabolism.Data {

    public class EntityData {
        public int ID { get; protected set; }

        public static DbWrapper Database { get; set; }
    }

}
