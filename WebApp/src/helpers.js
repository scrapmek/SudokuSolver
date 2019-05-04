const getStatePropertyFromString = (object, string) => {
    const targetFieldPathList = string.split('/');
    let currentProp = object;

    targetFieldPathList.forEach((pathNode) => {
      currentProp = currentProp[pathNode];
    });

    return currentProp;
}

export { getStatePropertyFromString };