import React, { useEffect } from "react";
import { useState } from "react";
import { useMutation, useQueryClient } from "react-query";
import ITodo from "../api/ITodo";
import { changeTodo, deleteTodo } from "../api/TodoApi";

export const Todo = (props: { key: number; todo: ITodo }) => {
  const queryClient = useQueryClient();
  const [todoValue, setTodoValue] = useState<string>(props.todo.Item);
  const [touched, setTouched] = useState<boolean>(false);

  const deleteTodoMutation = useMutation("deleteTodo", {
    mutationFn: deleteTodo,
    onSuccess: () => queryClient.invalidateQueries(["todos"]),
  });
  const updateTodoMutation = useMutation("updateTodo", {
    mutationFn: changeTodo,
    onSuccess: () => queryClient.invalidateQueries(["todos"]),
  });

  const handleDelete = (e) => {
    deleteTodoMutation.mutate(props.todo.Id);
    setTouched(false);
  };

  const handleUpdate = (e) => {
    updateTodoMutation.mutate({ Id: props.todo.Id, Item: todoValue });
    setTouched(false);
  }
   

  const handleCancel = (e) => {
    setTodoValue(props.todo.Item);
    setTouched(false);
  };

  const handleChange = (e) => {
    setTodoValue(e.target.value);
    setTouched(true);
  };

  return (
    <div key={props.key}>
      <div>Id{props.todo.Id}</div>
      <div>Id{props.todo.Item}</div>
      Item
      <input type="text" value={todoValue} onChange={handleChange} />
      {touched ? (
        <div>
          <button onClick={handleCancel}> Cancel</button>{" "}
          <button onClick={handleUpdate}> Save</button>
        </div>
      ) : (
        <button onClick={handleDelete}> Delete</button>
      )}
    </div>
  );
};
