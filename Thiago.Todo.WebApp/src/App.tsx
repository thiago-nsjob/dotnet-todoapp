import { TodoPage } from "./pages/TodoPage";
import { QueryClient, QueryClientProvider, useQuery } from "react-query";
import styles from "./App.module.css";
const queryClient = new QueryClient();

const App = () => {
  return (
    <div className={styles.app}>
      <QueryClientProvider client={queryClient}>
        <TodoPage />
      </QueryClientProvider>
    </div>
  );
};

export default App;
