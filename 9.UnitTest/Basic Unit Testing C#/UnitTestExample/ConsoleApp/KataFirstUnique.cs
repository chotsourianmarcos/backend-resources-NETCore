namespace ConsoleApp
{
    public class KataFirstUnique
    {
        public int Solution(int[] A)
        {
            int defaultResult = -1;
            List<int> notRepeatedNums = new List<int>();

            for (var i = 0; i < A.Length; i++)
            {
                var counter = 0;
                for (var j = 0; j < A.Length; j++)
                {
                    if (A[i] == A[j])
                    {
                        counter++;
                    }
                }
                if (counter == 1)
                {
                    notRepeatedNums.Add(A[i]);
                }
            }

            if (notRepeatedNums.Count > 0)
            {
                return notRepeatedNums[0];
            }
            else
            {
                return defaultResult;
            }
        }
    }
}