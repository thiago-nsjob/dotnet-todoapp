import ITodo from "../api/ITodo";
import { Todo } from "../components/Todo";
import { NewTodo } from "../components/NewTodo";
import { Divider, Paper } from "@mui/material";
import { useQuery } from "react-query";
import { getTodos } from "../api/TodoApi";
import styles from "./TodoPage.module.css";

export const TodoPage = () => {

  const { status, data } = useQuery<ITodo[], Error>("todos", getTodos);

  return status === "loading" ? (
    <span>Loading...</span>
  ) : (
    <Paper elevation={3} className={styles.page}>
      <h1>Thiago's ToDo App</h1>
      <Divider />
      <h3>Create a Todo</h3>
      <NewTodo />
      <Divider />
      <h3>TodoList</h3>
      {data?.map((todo) => (
        <Todo todo={todo} key={todo.Id} />
      ))}
    </Paper>
  );
};
