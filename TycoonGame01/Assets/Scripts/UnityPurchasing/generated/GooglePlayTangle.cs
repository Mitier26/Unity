// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("1DJAlJMIaegXzjxuTu3ZJQPLRpg9yTpjJ3P/l7js7DO/Hi5G32f/v/59c3xM/n12fv59fXztahQEE+Sm0139KuFTiwDmnxLomq5lCGxSSQ3utJ0tJ25dkahQwDQXKy7lPdVcp4EABcwxlAc22l7rIFzuNcMXk+oVTP59XkxxenVW+jT6i3F9fX15fH9b6tstnPgEly6Vw48lHBgSOuXjnqXv7yXmrsZR9YXUnwaHu3RSFvfSNFm2mGbYv52C4ew6LDv3hkdJNdt5YgknM9qneOyRDwBcSQZdH2a0LnSUNbukRUni0O3iCn9ixEOoEYm+GLT3ozFW/pQIFPInWf+G4Vb0wtsVAHER7Z6vLWd0dHV7DQ+AXDr2Dxalkl7AxJJg+35/fXx9");
        private static int[] order = new int[] { 11,8,8,12,10,9,11,9,12,9,12,12,13,13,14 };
        private static int key = 124;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
