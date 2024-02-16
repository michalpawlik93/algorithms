import { HashSet } from "../dataStructures/hashSet";
import {
  removeDuplicatesRecursion,
  removeByArray,
} from "../exercies/stringRemoveDuplicates";

(function () {
  const str = "adamas";
  const strArray = str.split("");
  console.log(strArray);
  console.log("removeRecusrion result:", removeDuplicatesRecursion(strArray));
  console.log("removeByArray result:", removeByArray(strArray));

  const hashSet = new HashSet();
  hashSet.createFromArray(strArray);
  console.log("Custom set result:", hashSet.set);
})();
