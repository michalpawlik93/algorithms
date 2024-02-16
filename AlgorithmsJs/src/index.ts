import express, { Express, Request, Response } from "express";
import dotenv from "dotenv";
import { callStringRemoveDuplicatesTest } from "./exercies/stringRemoveDuplicates";
import { stringReverseTest } from "./exercies/stringReverse";
import { longestWordInSentenceTest } from "./exercies/longestWOrdInSentence";

dotenv.config();
const app: Express = express();
const port = process.env.PORT || 3000;

app.use(express.static("src"));

app.get("*", (req: Request, res: Response) => {
  callStringRemoveDuplicatesTest("adams");
  stringReverseTest("adams");
  longestWordInSentenceTest("My adams have something long.");
});

app.listen(port, () => {
  console.log(`[server]: Server is running at http://localhost:${port}`);
});
