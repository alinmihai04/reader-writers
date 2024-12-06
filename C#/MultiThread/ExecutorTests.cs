using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiThread.Data;

namespace MultiThread
{
    [TestClass]
    public class ExecutorTests
    {
        private static string[] testValues1 =
        {
            "Lorem ipsum odor amet, consectetuer adipiscing elit.",
            "Vulputate praesent ut himenaeos montes netus sit ac.",
            "Enim nisl mollis; placerat natoque ornare odio libero interdum.",
            "Curabitur ante potenti ullamcorper tellus at nullam euismod ornare venenatis.",
            "Ornare sem neque curae suscipit amet elit egestas.",
            "Urna aliquet facilisi convallis consectetur integer; lacus parturient aliquam."
        };

        private static string[] testValues2 =
        {
            "fffkpk439to65mkbfkfhudsofffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsfhjewkfesfdsfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsfffkpk439to65mkbfkfhudsof84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfdsf84nfkjnsfdgfdgfdgfdgfdgfkfhjewkfesfds",
            "rohvitretretretfdgfdgfdgfdgfdgretrgfdg43545765764242354355sdhuvru5nngfgfgfgdffdgfdgfdgjxgfdgfdsfsdhiu45htkjgfdgfdgfdgfdgfdggfskjgfgrohvitretretretfdgfdgfdgfdgfdgretrgfdg43545765764242354355sdhuvru5nngfgfgfgdffdgfdgfdgjxgfdgfdsfsdhiu45htkjgfdgfdgfdgfdgfdggfskjgfgrohvitretretretfdgfdgfdgfdgfdgretrgfdg43545765764242354355sdhuvru5nngfgfgfgdffdgfdgfdgjxgfdgfdsfsdhiu45htkjgfdgfdgfdgfdgfdggfskjgfgrohvitretretretfdgfdgfdgfdgfdgretrgfdg43545765764242354355sdhuvru5nngfgfgfgdffdgfdgfdgjxgfdgfdsfsdhiu45htkjgfdgfdgfdgfdgfdggfskjgfgrohvitretretretfdgfdgfdgfdgfdgretrgfdg43545765764242354355sdhuvru5nngfgfgfgdffdgfdgfdgjxgfdgfdsfsdhiu45htkjgfdgfdgfdgfdgfdggfskjgfg",
            "a;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsfa;spo;'spw;[2r;3[r;43[r;fkciuhucmrenk45yr 322c ;r'lf;s'dsf",
            "gfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfdsgfdsgdsfdsfdafdgfdnk5y32urf7vf3g3t4hj3rgfdgfdgsdfdsfds",
            "fsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32jfsdfdsfsdfds4rhfdgfdgfdgthtrfdfdh5bn435b432543nvnf6ryft32gbj3c r evbydf5g32d n32mu2yfh632hevx2x2iz10w20-80l9tnrfdjy32j",
            "tretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf gtretretretfdgfdgfdgfdgfdgretrret45tr4e3rvi uycxchn32fvhjedfvjbskhtcbf43mf 4nm45tnvt ckf g",
            "gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34gfdgh7v4t4kjl323767095%^$%#$%#@!4idgfdgfdgfdgfdgfd4j24iytoerbewjrh43kjbrmnsmctx guwn4 n f p0dsoa2koed34"
        };

        private static List<StorageTask> GenerateTasks(int storageSize, int numberOfTasks,
            double readersToWritersRatio, string[] values)
        {
            var random = new Random();

            return Enumerable.Range(0, numberOfTasks).Select(i => new StorageTask
            {
                Index = random.Next(storageSize),
                Data = random.NextDouble() > readersToWritersRatio ? values[random.Next(values.Length)] : null
            }).ToList();
        }

        private void ExecuteWork(int numberOfThreads, int numberOfTasks, double readersToWritersRatio, string[] values,
            int storageSize, int blockSize, int readDuration, int writeDuration, LockType lockType, int timeout)
        {
            var tasks = GenerateTasks(storageSize, numberOfTasks, readersToWritersRatio, values);
            var results = new TaskExecutor(storageSize, blockSize, readDuration, writeDuration)
                .ExecuteWork(numberOfThreads, tasks, lockType);
        }

        [TestMethod]
        public void ExecuteWorkReaderPreferred()
        {
            ExecuteWork(10, 100, 0.2, testValues1, testValues1.Length, 255, 100, 250, LockType.ReaderPreferred, 10);
        }
    }
}
