function validSolution(board) {
  function isValidGroup(group) {
    return (
      group.length === 9 &&
      !group.includes(0) &&
      group.slice().sort().join("") === "123456789"
    );
  }

  function getColumn(board, colIndex) {
    return board.map((row) => row[colIndex]);
  }

  function getBlock(board, startRow, startCol) {
    const block = [];
    for (let r = 0; r < 3; r++) {
      for (let c = 0; c < 3; c++) {
        block.push(board[startRow + r][startCol + c]);
      }
    }
    return block;
  }

  if (!board.every(isValidGroup)) {
    return false;
  }

  for (let i = 0; i < 9; i++) {
    if (!isValidGroup(getColumn(board, i))) {
      return false;
    }
  }

  const blockStarts = [0, 3, 6];
  for (let row of blockStarts) {
    for (let col of blockStarts) {
      if (!isValidGroup(getBlock(board, row, col))) {
        return false;
      }
    }
  }

  return true;
}

const trueArray = [
  [5, 3, 4, 6, 7, 8, 9, 1, 2],
  [6, 7, 2, 1, 9, 5, 3, 4, 8],
  [1, 9, 8, 3, 4, 2, 5, 6, 7],
  [8, 5, 9, 7, 6, 1, 4, 2, 3],
  [4, 2, 6, 8, 5, 3, 7, 9, 1],
  [7, 1, 3, 9, 2, 4, 8, 5, 6],
  [9, 6, 1, 5, 3, 7, 2, 8, 4],
  [2, 8, 7, 4, 1, 9, 6, 3, 5],
  [3, 4, 5, 2, 8, 6, 1, 7, 9],
];
const falseArray = [
  [5, 3, 4, 6, 7, 8, 9, 1, 2],
  [6, 7, 2, 1, 9, 0, 3, 4, 8],
  [1, 0, 0, 3, 4, 2, 5, 6, 0],
  [8, 5, 9, 7, 6, 1, 0, 2, 0],
  [4, 2, 6, 8, 5, 3, 7, 9, 1],
  [7, 1, 3, 9, 2, 4, 8, 5, 6],
  [9, 0, 1, 5, 3, 7, 2, 1, 4],
  [2, 8, 7, 4, 1, 9, 6, 3, 5],
  [3, 0, 0, 4, 8, 1, 1, 7, 9],
];

console.log(validSolution(trueArray));
console.log(validSolution(falseArray));
