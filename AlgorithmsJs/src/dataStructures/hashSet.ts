export class HashSet {
  set: Record<string, LinkedList>;
  constructor() {
    //dictionary of hashKey and linked list
    this.set = {};
  }
  createFromArray(array: string[]) {
    array.forEach((item) => {
      this.add(item);
    });
  }

  add(text: string) {
    const hashKey = this.calculateHash(text);
    if (this.set[hashKey]) {
      const existsInLinkedList = this.set[hashKey].find(text);
      if (!existsInLinkedList) {
        this.set[hashKey].append(text);
      }
    } else {
      const newLinkedList = new LinkedList();
      newLinkedList.append(text);
      this.set[hashKey] = newLinkedList;
    }
  }

  calculateHash(text: string) {
    return text;
  }
}

class LinkedList {
  head: Node | null;
  constructor() {
    this.head = null;
  }
  append(data: any) {
    const newNode = new Node(data);
    if (!this.head) {
      this.head = newNode;
      return;
    }

    let current = this.head;
    while (current.next) {
      current = current.next;
    }

    current.next = newNode;
  }
  find(data: any) {
    let current = this.head;
    while (current) {
      if (current.data === data) {
        return true;
      }
      current = current.next;
    }
    return false;
  }
}

class Node {
  data: any;
  next: Node | null;
  constructor(data: any) {
    this.data = data;
    this.next = null;
  }
}
