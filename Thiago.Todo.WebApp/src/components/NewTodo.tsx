import { Button, Paper, TextField } from "@mui/material";
import { useState } from "react";
import { useQueryClient, useMutation } from "react-query";
import { createTodo } from "../api/TodoApi";

export const NewTodo = (props: {}) => {
  const queryClient = useQueryClient();

  const newTodoMutation = useMutation("createTodo", {
    mutationFn: createTodo,
    onSuccess: () => queryClient.invalidateQueries(["todos"]),
  });

  const [state, setState] = useState({
    newTodo: "",
    newTodoTouched: false,
  });

  const handleOnChange = (e) => {
    setState({
      ...state,
      newTodo: e.target.value,
      newTodoTouched: e.target.value !== "",
    });
  };

  const handleOnNewTodo = (e) => {
    newTodoMutation.mutate({ Id: 0, Item: state.newTodo });
  };
  return (
    <div className="todo-row">
       
      <TextField className="todo-input"
        id="outlined-basic"
        label="New Todo"
        variant="outlined"
        placeholder="Type your new todo here"
        onChange={handleOnChange}
        sx={{width: '90%', paddingRight:'.5em'}} 
      />
      {state.newTodoTouched && (
        <Button variant="contained" color="success" onClick={handleOnNewTodo}>
          Add
        </Button>
      )}
    </div>
  );
};
