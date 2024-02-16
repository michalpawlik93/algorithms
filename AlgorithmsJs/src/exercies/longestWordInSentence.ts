export function longestWordInSentenceTest(sentence: string) {
  if (sentence.length === 0) {
    console.log("Empty sentence");
    return;
  }

  const arr = sentence.split(" ");
  let longestWordLength: number = 0;
  let longestWord: string | null = null;
  arr.forEach((word) => {
    if (word.length > longestWordLength) {
      longestWordLength = word.length;
      longestWord = word;
    }
  });
  console.log(longestWord);
}
