//*****************************************************************************
//** 2707. Extra Characters in a String   leetcode                           **
//*****************************************************************************


#define INF 51 // Larger than the maximum possible length of `s`

int minExtraChar(char *s, char **dictionary, int dictionarySize) {
    int slen = strlen(s);
    int dp[slen + 1];  // dp[i] represents the minimum extra characters up to index i
    for (int i = 0; i <= slen; i++) {
        dp[i] = INF;  // Initialize with a large number
    }
    dp[0] = 0;  // No extra characters at the start
    
    // Check each index in the string `s`
    for (int i = 0; i < slen; i++) {
        // If dp[i] is already INF, skip it as it's unreachable
        if (dp[i] == INF) continue;
        
        // Try every dictionary word starting at index `i`
        for (int j = 0; j < dictionarySize; j++) {
            int len = strlen(dictionary[j]);
            if (i + len <= slen && strncmp(s + i, dictionary[j], len) == 0) {
                // If the dictionary word matches at position `i`, update dp[i + len]
                dp[i + len] = (dp[i + len] < dp[i]) ? dp[i + len] : dp[i];
            }
        }
        // Update the dp for extra character case
        dp[i + 1] = (dp[i + 1] < dp[i] + 1) ? dp[i + 1] : dp[i] + 1;
    }

    return dp[slen];  // The answer will be the minimum extra characters at the end of the string
}
