import org.apd.executor.LockType;
import org.apd.executor.StorageTask;
import org.apd.executor.TaskExecutor;

import java.util.List;
import java.util.Random;
import java.util.stream.IntStream;

public class Main {

    public static void main(String[] args)
    {
        executeWorkReaderPreferred1();
    }

    private final static String[] testValues1 = {
            "Lorem ipsum odor amet, consectetuer adipiscing elit.",
            "Vulputate praesent ut himenaeos montes netus sit ac.",
            "Enim nisl mollis; placerat natoque ornare odio libero interdum.",
            "Curabitur ante potenti ullamcorper tellus at nullam euismod ornare venenatis.",
            "Ornare sem neque curae suscipit amet elit egestas.",
            "Urna aliquet facilisi convallis consectetur integer; lacus parturient aliquam."
    };

    private final static String[] testValues2 = {
            "fffkpk439to65mkbfkfhudsofffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsfhjewkfesfdsfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsf84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfds",
            "rohvitretretretfdgfdgfdgfdgfdgretrgfdg43545765764242354355sdhuvru5nngfgfgfgdffdgfdgfdgjxgfdgfdsfsdhiu45htkjgfdgfdgfdgfdgfdggfskjgfgrohvitretretretfdgfdgfdgfdgfdgretrgfdg43545765764242354355sdhuvru5nngfgfgfgdffdgfdgfdgjxgfdgfdsfsdhiu45htkjgfdgfdgfdgfdgfdggfskjgfgrohvitretretretfdgfdgfdgfdgfdgretrgfdg43545765764242354355sdhuvru5nngfgfgfgdffdgfdgfdgjxgfdgfdsfsdhiu45htkjgfdgfdgfdgfdgfdggfskjgfgrohvitretretretfdgfdgfdgfdgfdgretrgfdg43545765764242354355sdhuvru5nngfgfgfgdffdgfdgfdgjxgfdgfdsfsdhiu45htkjgfdgfdgfdgfdgfdggfskjgfgrohvitretretretfdgfdgfdgfdgfdgretrgfdg43545765764242354355sdhuvru5nngfgfgfgdffdgfdgfdgjxgfdgfdsfsdhiu45htkjgfdgfdgfdgfdgfdggfskjgfg",
            "a;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsf",
            "gfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfds",
            "fsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32j",
            "tretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf g",
            "gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34"
    };

    private static List<StorageTask> generateTasks(int storageSize, int numberOfTasks, double readersToWritersRatio, String[] values) {
        return IntStream.range(0, numberOfTasks).mapToObj(i -> {
            var random = new Random();
            return new StorageTask(random.nextInt(storageSize),
                    random.nextDouble() > readersToWritersRatio ?
                            values[random.nextInt(values.length)] :
                            null);
        }).toList();
    }

    static void executeWork(int numberOfThreads, int numberOfTasks, double readersToWritersRatio, String[] values,
                     int storageSize, int blockSize, long readDuration, long writeDuration, LockType lockType, int timeout) {
            var tasks = generateTasks(storageSize, numberOfTasks, readersToWritersRatio, values);
            var results = new TaskExecutor(storageSize, blockSize, readDuration, writeDuration)
                    .ExecuteWork(numberOfThreads, tasks, lockType);
    }

    static void executeWorkReaderPreferred1() {
        executeWork(10, 100, 0.2, testValues1, testValues1.length, 255, 100, 250, LockType.ReaderPreferred, 10);
    }

}
