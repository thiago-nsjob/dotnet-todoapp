import ITodo from "../api/ITodo";
import { Todo } from "../components/Todo";
import { createTodo, getTodos } from "../api/TodoApi";
import { useMutation, useQuery, useQueryClient } from "react-query";
import styles from "./TodoPage.module.css";
import { useState } from "react";

export const TodoPage = () => {
  const { status, data } = useQuery<ITodo[], Error>("todos", getTodos);
 
  const queryClient = useQueryClient();

  const newTodoMutation = useMutation("createTodo", {
    mutationFn: createTodo,
    onSuccess: () => queryClient.invalidateQueries(['todos'])
  });

  const [state, setState] = useState({
    newTodo: "",
    newTodoTouched: false,
  });

  function handleOnChange(e) {
    setState({
      ...state,
      newTodo: e.target.value,
      newTodoTouched: e.target.value !== "",
    });
  }

  function handleOnNewTodo(e) {
    newTodoMutation.mutate({ Id: 0, Item: state.newTodo });
  }

  return status === "loading" ? (
    <span>Loading...</span>
  ) : (
    <div className={styles.page}>
      <h1>TodoPage</h1>
      <input
        type="text"
        placeholder="Type your new todo here"
        onChange={handleOnChange}
      ></input>
      {state.newTodoTouched && (
        <button onClick={handleOnNewTodo}> Add Todo</button>
      )}

      <h3>TodoList</h3>
      {data?.map((todo) => (
        <Todo todo={todo} key={todo.Id} />
      ))}
    </div>
  );
};
