import * as React from "react";

import { Button, Loader } from "~/components/framework";

const Home: React.FC = () => {
    const [loading, setLoading] = React.useState(true);

    return loading ? <Loader /> : <div>Hey</div>;
};

export default Home;
