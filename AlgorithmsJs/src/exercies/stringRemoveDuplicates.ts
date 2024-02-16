import { HashSet } from "../dataStructures/hashSet";

export function callStringRemoveDuplicatesTest(input: string) {
  const strArray = input.split("");
  console.log(strArray);
  console.log("removeRecusrion result:", removeDuplicatesRecursion(strArray));
  console.log("removeByArray result:", removeByArray(strArray));

  const hashSet = new HashSet();
  hashSet.createFromArray(strArray);
  console.log("Custom set result:", hashSet.set);
}

function removeByArray(inputArray: string[]) {
  const result: string[] = [];
  if (inputArray.length === 0) return result;

  for (let i = 0; i < inputArray.length; i++) {
    let isDuplicate = false;
    for (let j = 0; j < result.length; j++) {
      if (inputArray[i] === result[j]) {
        isDuplicate = true;
        break;
      }
    }
    if (!isDuplicate) {
      result.push(inputArray[i]);
    }
    isDuplicate = false;
  }
  return result;
}

function removeDuplicatesRecursion(inputArray: string[]) {
  if (inputArray.length === 0) return [];
  return removeRecusrion(inputArray, inputArray[0]);
}

function removeRecusrion(inputArray: string[], toRemove: string): string[] {
  const filteredByItem = inputArray.filter((item) => item !== toRemove);
  if (filteredByItem.length === 0) return [toRemove];
  return [toRemove, ...removeRecusrion(filteredByItem, filteredByItem[0])];
}
