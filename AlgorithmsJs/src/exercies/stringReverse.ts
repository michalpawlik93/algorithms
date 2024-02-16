export function stringReverseTest(input: string) {
  const arr = input.split("");
  const result: string[] = [];
  for (let i = arr.length - 1; i >= 0; i--) {
    result.push(arr[i]);
  }
  console.log(result.join(""));
}
